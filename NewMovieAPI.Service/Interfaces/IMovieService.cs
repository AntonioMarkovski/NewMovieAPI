using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewMovieAPI.Entities;

namespace NewMovieAPI.Service.Interfaces
{
    public interface IMovieService
    {
        void Add(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
        Task<Movie> GetMovie(int id);
        Task<IEnumerable<Movie>> GetMovies();
        IEnumerable<Movie> GetMovies2();
    }
}