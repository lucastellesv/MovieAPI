using Microsoft.Extensions.Configuration;
using MovieAPI.Data;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class MovieService
    {
        public IConfiguration configuration { get; }
        private readonly ApplicationDbContext db;

        public MovieService(IConfiguration Configuration, ApplicationDbContext context)
        {
            configuration = Configuration;
            db = context;
        }

        public List<Movie> List()
        {
            return db.Movies.ToList();
        }

        public ResponseModel Add(Movie movie)
        {
                Movie FindMovie = db.Movies.Where(x => x.Title == movie.Title).FirstOrDefault();
                if(FindMovie == null)
                {
                    db.Add(movie);
                    db.SaveChanges();
                    return new ResponseModel("filme cadastrado com sucesso", 200);
                }
            return new ResponseModel("O filme já existe", 404);
        }
        public ResponseModel Delete(int Id)
        {
            var FindMovieId = db.Movies.Where(x => x.Id == Id).FirstOrDefault();
            if(FindMovieId != null)
            {
                db.Remove(FindMovieId);
                db.SaveChanges();
                return new ResponseModel("Filme excluido com sucesso", 200);
            }
            return new ResponseModel("O filme não existe", 404);
        }
    }
}
