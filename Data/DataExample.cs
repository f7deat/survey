using System.Collections.Generic;
using Survey.Entities;
using System;
using Survey.Enums;

namespace Survey.Data
{
    public class DataExample
    {
        public static List<Ticket> Tickets = new List<Ticket>() {
            new Ticket() { 
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Đánh giá kết quả cuối năm",
                Status = ETicketStatus.Draft
             },
            new Ticket{
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Đánh giá kết quả cuối quý",
                Status = ETicketStatus.Publish
            }
        };
    }
}