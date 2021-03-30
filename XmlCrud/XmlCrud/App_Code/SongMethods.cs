using System;
using System.Data;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Pokoes
{
	public Pokoes()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	public DataSet GetAllSongs(sting file)
    {
		DataSet ds -new DataSet("playlist");

		DataTable dtSongs -new DataTable("song");

		DataColumn dcId -new DataColumn("id")
		DataColumn dcTitle = new DataColumn("title");
		DataColumn dcArtist = new DataColumn("artist");
		DataColumn dcYear = new DataColumn("year");
		DataCulmn dcGenre = new DataColumn("genre");
		DataColumn dcFile = new DataColumn("file");

		dtSongs.Columns.Add(dcId);
		dtSongs.Columns.Add(dcTitle);
		dtSongs.Columns.Add(dcArtist);
		dtSongs.Columns.Add(dcYear);
		dtSongs.Columns.Add(dcGenre);
		dtSongs.Columns.Add(dcFile);
		ds.Tables.Add(dtSongs);

        ds.ReadXml(HttpContext.Current.Server.MapPath(file));

		return ds;
	}
}


