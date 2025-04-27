﻿using Microsoft.EntityFrameworkCore;
using SahafManyToManyDb.Abstracts.Repositories;
using SahafManyToManyDb.Data;

namespace SahafManyToManyDb.Repositories
{
    /// <summary>
    /// tüm ortak metodları tek bir yerden yazıp tüm entity ler için kullanabileceğimiz generic repository sınıfı
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SahafDbContext context;
        protected DbSet<TEntity> table;
        public BaseRepository(SahafDbContext _context)
        {
            context = _context;
            table = context.Set<TEntity>();
        }
        public void Ekle(TEntity entity)
        {
            table.Add(entity);
            context.SaveChanges();
        }
        public void Guncelle(TEntity entity)
        {
            table.Update(entity);
            context.SaveChanges();
        }
        public void Sil(int id)
        {
            var entity = Bul(id);
            if (entity != null)
            {
                table.Remove(entity);
                context.SaveChanges();
            }
        }
        public TEntity Bul(int id)
        {
            return table.Find(id);
        }
        public List<TEntity> Listele()
        {
            return table.ToList();
        }
    }
}
