using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using NewMovieAPI.Entities;
using System.Threading.Tasks;

namespace NewMovieAPI.Repository.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
        Task<Movie> GetMovie(int id);
        Task<IEnumerable<Movie>> GetMovies();
        IEnumerable<Movie> GetMovies2();

    }
}