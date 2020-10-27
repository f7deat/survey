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

        public static List<Quiz> Quizzes = new List<Quiz>() {
            new Quiz {
                Id = 1, Title = "Bạn có hài lòng về chương trình giảng dạy hiện tại", TicketId = 1
            },
            new Quiz {
                Id = 2, Title = "Bạn có hài lòng về cơ sở vật chất hiện tại", TicketId = 1
            }
        };
    }
}