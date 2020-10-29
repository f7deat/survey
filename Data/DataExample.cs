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
                Status = ETicketStatus.Publish
             },
            new Ticket{
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Đánh giá kết quả cuối quý",
                Status = ETicketStatus.Completed
            }
        };

        public static List<Quiz> Quizzes = new List<Quiz>() {
            new Quiz {
                Id = 1, QuizType = QuizType.Content1, Title = "Giảng viên đã thông tin rõ mục tiêu, yêu cầu và nội dung môn học, trọng tâm, trọng điểm, tài liệu, vật chất của từng bài giảng. ", TicketId = 1
            },
            new Quiz {
                Id = 2, QuizType = QuizType.Content1, Title = "Giảng viên đã thông tin đầy đủ về kế hoạch giảng dạy, huấn luyện và tiêu chí đánh giá kết quả học tập.", TicketId = 1
            },
            new Quiz {
                Id = 3, QuizType = QuizType.Content1, Title = "Giảng viên đã chuẩn bị tốt các điều kiện để thực hành giảng bài, huấn luyện (giáo án, địa điểm, vật chất, trang thiết bị dạy học...)", TicketId = 1
            },
            new Quiz {
                Id = 4, QuizType = QuizType.Content2, Title = "Giảng viên đã thực hiện đúng kế hoạch, nội dung bài giảng, huấn luyện đã được thông qua.", TicketId = 1
            }
        };

        public static List<Statistical> Statisticals = new List<Statistical>();

        public static List<User> Users = new List<User>() {
            new User {
                Id = "12AB001", Name = "TanDC", Email = "tandc@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Admin, Password = "123"
            },
            new User {
                Id = "12AB002", Name = "LinhLP", Email = "linhlp@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123"
            },
            new User {
                Id = "12AB003", Name = "HungNV", Email = "hungnv@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123"
            }
        };
    }
}