using System;
using System.Collections.Generic;

namespace AdondeVamos.Model.DTO
{
    public class PageResultDTO<T>
    {
        public List<T> Data { get; private set; }

        public PageResultDTO(List<T> items)
        {   
            Data = items ?? new List<T>(items);
        }
    }
}