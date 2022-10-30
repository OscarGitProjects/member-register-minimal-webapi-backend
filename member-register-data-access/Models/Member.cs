using System.Text;

namespace MemberRegister.DataAccess.Models;

public class Member
{
    public int Id { get; set; }

    public string Fornamn { get; set; }

    public string Efternamn { get; set; }

    public string Adress { get; set; }

    public string Postnummer { get; set; }

    public string Postort { get; set; }

    public DateTime Skapatdatum { get; set; }

    public DateTime Senastuppdateraddatum { get; set; }

    public override string ToString()
    {
        StringBuilder strBuild = new StringBuilder("Id: " + this.Id);
        strBuild.Append(System.Environment.NewLine);

        strBuild.Append(this.Fornamn + " " + this.Efternamn);
        strBuild.Append(System.Environment.NewLine);

        strBuild.Append(this.Adress);
        strBuild.Append(System.Environment.NewLine);

        strBuild.Append(this.Postnummer);
        strBuild.Append(" ");
        strBuild.Append(this.Postort);

        strBuild.Append(System.Environment.NewLine);
        strBuild.Append("Creation date: " + this.Skapatdatum.ToShortDateString());

        strBuild.Append(System.Environment.NewLine);
        strBuild.Append("Latest update date: " + this.Senastuppdateraddatum.ToShortDateString());

        return strBuild.ToString();
    }
}