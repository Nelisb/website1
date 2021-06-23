using System.Data;
using System.Web;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace XmlCrud.App_Code
{
	public class Pokoes
	{
		DataSet ds = new DataSet("playlist");

		public Pokoes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public DataSet GetAllSongs(string filePath)
		{
			ds = new DataSet("playlist");

			DataTable dtSongs = new DataTable("song");

			DataColumn dcId = new DataColumn("id");
			DataColumn dcTitle = new DataColumn("title");
			DataColumn dcArtist = new DataColumn("artist");
			DataColumn dcYear = new DataColumn("year");
			DataColumn dcGenre = new DataColumn("genre");
			DataColumn dcFile = new DataColumn("file");

			dtSongs.Columns.Add(dcId);
			dtSongs.Columns.Add(dcTitle);
			dtSongs.Columns.Add(dcArtist);
			dtSongs.Columns.Add(dcYear);
			dtSongs.Columns.Add(dcGenre);
			dtSongs.Columns.Add(dcFile);
			ds.Tables.Add(dtSongs);

			ds.ReadXml(HttpContext.Current.Server.MapPath(filePath));

			return ds;
		}
		public DataRow GetEmptyDataRow()
        {
			DataRow dr = ds.Tables["song"].NewRow();
			return dr;
        }
		public void CreateSong(DataRow dataRow, string filePath)
        {
			ds.Tables["song"].Rows.Add(dataRow);
			ds.WriteXml(HttpContext.Current.Server.MapPath(filePath));
        }
		public void DeleteSong(string id, string filePath)
        {
			DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + "'");
			if(drArray != null && drArray.Length > 0)
            {
				drArray[0].Delete();
				ds.WriteXml(HttpContext.Current.Server.MapPath(filePath));
            }
        }
	}


}