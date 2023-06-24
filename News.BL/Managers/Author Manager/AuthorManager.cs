using News.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public class AuthorManager : IAuthorManager
{
    private readonly IUnitOfWork unitOfWork;

    public AuthorManager(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }



    public List<AuthorReadDTO> GetAll()
    {
        List<Author> authorsFromDB = unitOfWork.AuthorsRepo.GetAll();

        return authorsFromDB.Select(a => new AuthorReadDTO
        {
            ID = a.ID,
            Name = a.Name,
            DOB = a.DOB,
            Bio = a.Bio,
        }).ToList();
    }

    public int Add(AuthorAddDTO authorAdd)
    {
        if (authorAdd is null)
        {
            return 0;
        }

        Author newAuthor = new Author()
        {
            ID = Guid.NewGuid(),
            Name = authorAdd.Name,
            DOB = authorAdd.DOB,
            Bio = authorAdd.Bio,
        };

        unitOfWork.AuthorsRepo.Add(newAuthor);

        return unitOfWork.Save();
    }

    public AuthorEditDTO? GetByID(Guid id)
    {
        Author? authorFromDB = unitOfWork.AuthorsRepo.GetByID(id);
        if (authorFromDB == null)
        {
            return null;
        }

        return new AuthorEditDTO
        {
            ID = authorFromDB.ID,
            Name = authorFromDB.Name,
            DOB = authorFromDB.DOB,
            Bio = authorFromDB.Bio,
        };
    }

    public int Update(AuthorEditDTO authorEdit)
    {
        Author? authorFromDB = unitOfWork.AuthorsRepo.GetByID(authorEdit.ID);
        if (authorFromDB == null)
        {
            return 0;
        }
        authorFromDB.Name = authorEdit.Name;
        authorFromDB.DOB = authorEdit.DOB;
        authorFromDB.Bio = authorEdit.Bio;

        return unitOfWork.Save();

    }

    public int Delete(Guid id)
    {
        Author? authorFromDb = unitOfWork.AuthorsRepo.GetByID(id);
        if (authorFromDb == null)
        {
            return 0;
        }
        unitOfWork.AuthorsRepo.Delete(authorFromDb);
        return unitOfWork.Save();
    }
}
