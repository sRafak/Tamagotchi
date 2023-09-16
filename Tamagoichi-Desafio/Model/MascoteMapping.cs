using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagoichi_Desafio.Model
{
    public class MascoteMapping
    {
        public Mapper mapper { get; set; }
        public MascoteMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pokemon, Mascote>();
            });

            this.mapper = new Mapper(config);
        }
    }
}
