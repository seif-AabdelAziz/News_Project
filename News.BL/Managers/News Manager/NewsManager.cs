using News.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.DAL;


namespace News.BL;

public class NewsManager : INewsManager
{
    private readonly IUnitOfWork unitOfWork;

    public NewsManager(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }



    public List<NewsReadDTO> ReadPublished()
    {
        var newsFromDB = unitOfWork.NewsRepo.PublishedNews();


        return newsFromDB.Select(n => new NewsReadDTO
        {
            ID = n.ID,
            Title = n.Title,
            ImageURL = n.ImageUrl
        }).ToList();
    }

    public NewsReadDetailsDTO? ReadDetails(Guid id)
    {
        var newsFromDB = unitOfWork.NewsRepo.NewsDetails(id);
        if (newsFromDB == null)
        {
            return null;
        }

        return new NewsReadDetailsDTO
        {
            ID = newsFromDB.ID,
            Title = newsFromDB.Title,
            NewsDetails = newsFromDB.NewsDetails,
            ImageUrl = newsFromDB.ImageUrl,
            PublicationDate = newsFromDB.PublicationDate,
            AuthorName = newsFromDB.Author.Name
        };
    }

    public List<NewsReadDetailsDTO> ReadAll()
    {
        var newsFromDB = unitOfWork.NewsRepo.GetAllWithAuthors();
        if (newsFromDB == null)
        {
            return null;
        }

        return newsFromDB.Select(n => new NewsReadDetailsDTO
        {
            ID = n.ID,
            Title = n.Title,
            NewsDetails = n.NewsDetails,
            ImageUrl = n.ImageUrl,
            PublicationDate = n.PublicationDate,
            AuthorName = n.Author.Name
        }).ToList();
    }

    public int Add(NewsAddDTO newsAddDTO)
    {
        if (newsAddDTO is null) { return 0; }

        News.DAL.News news = new DAL.News
        {
            ID = Guid.NewGuid(),
            Title = newsAddDTO.Title,
            NewsDetails = newsAddDTO.NewsDetails,
            ImageUrl = newsAddDTO.ImageUrl,
            CreationDate = DateTime.Now,
            PublicationDate = newsAddDTO.PublicationDate,
            AuthorID = newsAddDTO.AuthorID
        };

        unitOfWork.NewsRepo.Add(news);

        return unitOfWork.Save();
    }

    public int Update(NewsEditDTO newsEditDTO)
    {
        DAL.News? newsFromDB = unitOfWork.NewsRepo.GetByID(newsEditDTO.ID);
        if (newsFromDB is null) { return 0; }

        newsFromDB.Title = newsEditDTO.Title;
        newsFromDB.NewsDetails = newsEditDTO.NewsDetails;
        newsFromDB.ImageUrl = newsEditDTO.ImageUrl;
        newsFromDB.PublicationDate = newsEditDTO.PublicationDate;
        newsFromDB.AuthorID = newsEditDTO.AuthorID;

        return unitOfWork.Save();
    }

    public NewsEditDTO? EditNews(Guid id)
    {
        var newsFromDB = unitOfWork.NewsRepo.GetByID(id);
        if (newsFromDB is null) { return null; }

        return new NewsEditDTO
        {
            ID = newsFromDB.ID,
            Title = newsFromDB.Title,
            NewsDetails = newsFromDB.NewsDetails,
            ImageUrl = newsFromDB.ImageUrl,
            PublicationDate = newsFromDB.PublicationDate,
            AuthorID = newsFromDB.AuthorID,
        };
    }

    public int Delete(Guid id)
    {
        var newsFromDB = unitOfWork.NewsRepo.GetByID(id);
        if (newsFromDB is null) { return 0; }

        unitOfWork.NewsRepo.Delete(newsFromDB);

        return unitOfWork.Save();
    }
}
