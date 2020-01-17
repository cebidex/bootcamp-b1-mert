using net_core_bootcamp_b1_mert.DTOs;
using net_core_bootcamp_b1_mert.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net_core_bootcamp_b1_mert.Services
{
    public interface IHWEventService
    {
        public string Add(HWEventAddDto model);
        public string Update(HWEventUpdateDto model);
        public string Delete(Guid Id);
        public IList<HWEventGetDto> Get();
    }

    public class HWEventService : IHWEventService
    {
        private static readonly IList<HWEvent> data = new List<HWEvent>();
        public string Add(HWEventAddDto model)
        {
            var entity = new HWEvent
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow

            };
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.FinishDate = model.FinishDate;
            entity.Address = model.Address;
            entity.IsFree = model.IsFree;
            entity.Price = model.Price;
            entity.Subject = model.Subject;
            entity.Desc = model.Desc;

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

        public IList<HWEventGetDto> Get()
        {
            var result = new List<HWEventGetDto>();

            result = data
                .Where(x => !x.IsDeleted)
                .Select(s => new HWEventGetDto
                {
                    Id = s.Id,
                    CreatedAt = s.CreatedAt,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    FinishDate = s.FinishDate,
                    Address = s.Address,
                    IsFree = s.IsFree,
                    Price = s.Price,
                    Subject = s.Subject,
                    Desc = s.Desc
                })
                .ToList();
            return result;
        }

        public string Update(HWEventUpdateDto model)
        {
            var entity = data.Where(x => x.Id == model.Id && !x.IsDeleted).FirstOrDefault();
            if (entity == null)
            {
                return "ID Bulunamadi";
            }
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.FinishDate = model.FinishDate;
            entity.Address = model.Address;
            entity.IsFree = model.IsFree;
            entity.Price = model.Price;
            entity.Subject = model.Subject;
            entity.Desc = model.Desc;

            return ($"{entity.Id} basariyla degisti");
        }
    }
}