using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net_core_bootcamp_b1_mert.Services
{
    public interface IHWBookService
    {
        public string Add(HWBookAddDto model);
        public string Update(HWBookUpdateDto model);
        public string Delete(Guid Id);
        public IList<HWBookGetDto> Get();
    }
    public class HWBookService : IHWBookService
    {
        private static readonly IList<HWBook> data = new List<HWBook>();
        public string Add(HWBookAddDto model)
        {
            var entity = new HWBook
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow

            };
            entity.Name = model.Name;
            entity.Author = model.Author;
            entity.Publisher = model.Publisher;
            entity.ReleaseDate = model.ReleaseDate;
            entity.Price = model.Price;

            data.Add(entity);
            return model.Name + " Eklendi";
        }

        public string Delete(Guid Id)
        {
            var entity = data.Where(x => x.Id == Id).FirstOrDefault();
            if (entity == null)
            {
                return "ID Bulunamadi";
            }
            entity.IsDeleted = true;

            return entity.Name + " Silindi";
        }

        public IList<HWBookGetDto> Get()
        {
            var result = new List<HWBookGetDto>();

            result = data
                .Where(x => !x.IsDeleted)
                .Select(s => new HWBookGetDto
                {
                    Id = s.Id,
                    CreatedAt = s.CreatedAt,
                    Name = s.Name,
                    Author = s.Author,
                    Publisher = s.Publisher,
                    ReleaseDate = s.ReleaseDate,
                    Price = s.Price
                })
                .ToList();
            return result;
        }

        public string Update(HWBookUpdateDto model)
        {
            var entity = data.Where(x => x.Id == model.Id && !x.IsDeleted).FirstOrDefault();
            if (entity == null)
            {
                return "ID Bulunamadi";
            }
            entity.Name = model.Name;
            entity.Author = model.Author;
            entity.Publisher = model.Publisher;
            entity.ReleaseDate = model.ReleaseDate;
            entity.Price = model.Price;

            return ($"{entity.Id} basariyla degisti");
        }
    }
}
