using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL;

public class NewsContext : DbContext
{
    public NewsContext(DbContextOptions options) : base(options) { }

    public DbSet<News> News => Set<News>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Seeding Authors

        List<Author> authors = new List<Author>()
        {
            new Author(){ID=Guid.NewGuid(),Name="Jane Hong",DOB=new DateTime (1995,3,18),Bio="I'm Jane Hong, and I recently graduated with an advanced diploma from Smith secondary school. I'm seeking an internship where I can apply my skills in content creation and increase my experience in digital marketing."},
            new Author(){ID=Guid.NewGuid(),Name="John Grayson",DOB=new DateTime (1990,5,3),Bio="I'm John Grayson, and I'm a recent college graduate with a Bachelor's Degree in Web Design. I'm seeking a full-time opportunity where I can employ my programming skills."},
            new Author(){ID=Guid.NewGuid(),Name="Mathias Yeo",DOB=new DateTime (1988,4,8),Bio="I'm Mathias Yeo, and I'm passionate about writing engaging content for businesses. I specialise in topics like technology, travel and food."},
            new Author(){ID=Guid.NewGuid(),Name="Oliver Tan",DOB=new DateTime (1997,9,26),Bio="I'm Oliver Tan, and I'm passionate about social justice. I'm currently working as an assistant for Martin Law."},
            new Author(){ID=Guid.NewGuid(),Name="Ava Lee",DOB=new DateTime (1985,12,15),Bio="I'm Ava Lee, and I graduated from State University in May 2020. I'm interning as a grant writer and practising research and writing every day."},
        };
        #endregion

        #region News

        List<News> news = new List<News>()
        {
            new News(){ID=Guid.NewGuid(),Title="Declan Rice: Arsenal's improved £90m bid for West Ham captain rejected",NewsDetails="Declan Rice was made West Ham captain last summer; Arsenal signed Jorginho in January but Mikel Arteta remains keen to strengthen his midfield; Man City and Man Utd are also interested in the midfielder; this would be a club-record fee if accepted, surpassing £72m for Nicolas Pepe The fee, which would have been a club record for Arsenal, was understood to be £75m guaranteed plus £15m in add-ons, surpassing the £72m paid to Lille for Nicolas Pepe in 2019.",ImageUrl="https://e0.365dm.com/23/04/1600x900/skysports-declan-rice-west-ham_6126510.jpg?20230419163701",CreationDate=DateTime.Now,PublicationDate=DateTime.Now,AuthorID=authors[0].ID},
            new News(){ID=Guid.NewGuid(),Title="Kai Havertz to Arsenal? Why Chelsea are willing to let him go and why he is attractive to the Gunners",NewsDetails="Arsenal are trying to sign Kai Havertz from Chelsea; Blues hope to recoup most of the £75m fee they paid to sign him from Bayer Leverkusen in 2020; Germany international scored in the 2021 Champions League final but has a modest record at Stamford Bridge Arsenal are in talks to sign him for more than £60m after a three-year spell at Stamford Bridge during which he has struggled to find consistency following his £75m arrival from Bayer Leverkusen.",ImageUrl="https://e0.365dm.com/23/06/1600x900/skysports-kai-havertz-chelsea_6193745.jpg?20230620162204",CreationDate=DateTime.Now,PublicationDate=DateTime.Now,AuthorID=authors[3].ID},
            new News(){ID=Guid.NewGuid(),Title="James Maddison: Leicester want over £50m for midfielder with Newcastle, Tottenham pushing to sign midfielder",NewsDetails="Newcastle and Tottenham pushing to sign Leicester's James Maddison; Foxes want a fee in excess of £50m for England international; West Ham are one of a number of the clubs interested in Harvey Barnes; Leicester believe winger is worth north of £40m\r\n\r\n The Foxes consider Maddison their strongest asset and will not be deterred from their valuation despite being relegated and the midfielder having only one year left on his contract.",ImageUrl="https://e0.365dm.com/23/04/1600x900/skysports-james-maddison-leicester_6131549.jpg?20230424102127",CreationDate=DateTime.Now,PublicationDate=DateTime.Now,AuthorID=authors[2].ID},
            new News(){ID=Guid.NewGuid(),Title="Kalvin Phillips: England midfielder determined to stay and fight for his place at Man City",NewsDetails="Man City midfielder Kalvin Phillips: \"My intention is to stay there. We have just won the treble, so there is no reason for me to leave, other than if I am not playing I will obviously have to think about it. I cannot give it 12 months and say, 'I am not playing so I am going to leave'.\" The England international moved across the Pennines from Leeds last summer but has seen his game time restricted by a combination of injury and selection decisions.",ImageUrl="https://e0.365dm.com/23/01/1600x900/skysports-kalvin-phillips-man-city_6021120.jpg?20230111230538",CreationDate=DateTime.Now,PublicationDate=DateTime.Now,AuthorID=authors[1].ID},
            new News(){ID=Guid.NewGuid(),Title="Manchester United transfer news: Fresh bid expected for Chelsea's Mason Mount, Declan Rice still a target",NewsDetails="Manchester United are preparing to up their offer for midfielder Mason Mount after Chelsea rejected first two bids; it's thought the Blues want close to £65m; United are also monitoring Declan Rice's situation; the West Ham captain is being pursued by Arsenal\r\nThey have had two bids rejected - the latest worth £50m including add-ons. It's thought Chelsea want closer to £65m, but United have a limit which they will not go beyond.",ImageUrl="https://e0.365dm.com/23/06/1600x900/skysports-mason-mount-declan-rice_6195515.jpg?20230622094156",CreationDate=DateTime.Now,PublicationDate=DateTime.Now,AuthorID=authors[4].ID},
            new News(){ID=Guid.NewGuid(),Title="Chelsea transfer news: Blues confirm £52m Christopher Nkunku signing from RB Leipzig",NewsDetails="Chrisopher Nknunku has agreed to a six-year deal at Chelsea; Blues understood to have paid France international's £52m release clause; Nkunku contributed 16 goals and six assists in 25 league games for RB Leizpig this season Nkunku, who will officially become a Chelsea player on July 1, has agreed to a six-year deal at Stamford Bridge",ImageUrl="https://e0.365dm.com/23/06/1600x900/skysports-christopher-nkunku_6193220.jpg?20230620094245",CreationDate=DateTime.Now,PublicationDate=DateTime.Now,AuthorID=authors[4].ID},
        };
        #endregion

        modelBuilder.Entity<News>().HasData(news);
        modelBuilder.Entity<Author>().HasData(authors);
    }
}
