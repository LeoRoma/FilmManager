using FilmListHelperModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmListHelperController.Controllers
{
    public class FilmCRUDController
    {
        public Film SelectedFilm { get; set; }

        public List<Film> GetFilms()
        {
            using(var db = new FilmListHelperDbContext())
            {
                var filmList = db.Films.OrderBy(f => f.FilmTitle).ToList();
                
                return filmList;
            }   
        }

        public bool AddNewFilm(string title)
        {
            using (var db = new FilmListHelperDbContext())
            {
                var titleLower = title.ToLower();
                var filmList = db.Films.Select(film => film.FilmTitle).ToList();
                var filmListLowcase = filmList.ConvertAll(d => d.ToLower());
                if(filmListLowcase.Contains(titleLower))
                {
                    return false;
                }
                else
                {
                    db.Films.Add(
                            new Film
                            {
                                FilmTitle = title,
                                Date = DateTime.Now
                            }
                        );
                    db.SaveChanges();
                    return true;
                }            
            }
        }

        public void DeleteFilm(int filmId)
        {
            using (var db = new FilmListHelperDbContext())
            {
                var film = db.Films.Where(film => film.FilmId == filmId).SingleOrDefault();
                db.Remove(film);
                db.SaveChanges();
            }
        }

        public void UpdateFilm(int filmId, string filmTitle)
        {
            using(var db = new FilmListHelperDbContext())
            {
                var film = db.Films.Where(film => film.FilmId == filmId).SingleOrDefault();
                film.FilmTitle = filmTitle;
                db.SaveChanges();
            }
        }

        public void SetSelectedFilm(object selectedFilm)
        {
            SelectedFilm = (Film)selectedFilm;
        }
    }
}

