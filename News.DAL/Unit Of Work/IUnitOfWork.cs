using News.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL;

public interface IUnitOfWork
{
    public INewsRepo NewsRepo { get; }
    public IAuthorRepo AuthorsRepo { get; }

    int Save();
}
