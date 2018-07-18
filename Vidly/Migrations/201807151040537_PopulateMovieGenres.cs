namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 1,  'Action'          )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 2,  'Adventure'       )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 3,  'Comedy'          )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 4,  'Crime'           )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 5,  'Drama'           )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 6,  'Family'          )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 7,  'Historical'      )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 8,  'Horror'          )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 9,  'Musical / Dance' )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 10, 'Romance'         )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 11, 'Science Fiction' )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 12, 'War'             )");
            Sql("INSERT INTO MovieGenres ( Id, Genre ) VALUES ( 13, 'Western'         )");

        }

        public override void Down()
        {
        }
    }
}
