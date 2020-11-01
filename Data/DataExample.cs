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
                Name = "GV.LSTH - Hoàng Văn Dương",
                Status = ETicketStatus.Publish
             },
            new Ticket{
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "GV.LSTH - Đinh Thu Hương",
                Status = ETicketStatus.Completed
            }
        };
        public static List<Statistical> Statisticals = new List<Statistical>();
    }
}