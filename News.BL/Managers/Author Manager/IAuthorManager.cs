using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public interface IAuthorManager
{
    List<AuthorReadDTO> GetAll();
    int Add(AuthorAddDTO authorAdd);
    AuthorEditDTO? GetByID(Guid id);
    int Update(AuthorEditDTO authorEdit);
    int Delete(Guid id);
}
