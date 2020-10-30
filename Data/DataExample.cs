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
            },
            new Quiz {
                Id = 5, QuizType = QuizType.Content2, Title = "Nội dung giảng dạy đảm bảo tính Đảng, tính chính xác, khoa học, thiết thực, hữu ích và phù hợp nhận thức, năng lực của học viên.", TicketId = 1
            },
            new Quiz {
                Id = 6, QuizType = QuizType.Content2, Title = "Nội dung giảng dạy, huấn luyện đã cập nhật, đổi mới sát đúng với nội dung chương trình môn học.", TicketId = 1
            },
            new Quiz {
                Id = 7, QuizType = QuizType.Content3, Title = "Giảng viên có phương pháp truyền đạt rõ ràng, dễ hiểu, cuốn hút  tạo hứng khởi học tập học viên.", TicketId = 1
            },
            new Quiz {
                Id = 8, QuizType = QuizType.Content3, Title = "Giảng viên có kiến thức sâu rộng về môn học, kinh nghiệm công tác; có sự liên hệ thực tiễn phong phú, sinh động.", TicketId = 1
            },
            new Quiz {
                Id = 9, QuizType = QuizType.Content3, Title = "Phương pháp dạy học, huấn luyện của giảng viên đã góp phần phát triển tư duy sáng tạo của học viên, phát huy tính tự học, tự nghiên cứu; khuyến khích học viên nêu câu hỏi và bày tỏ quan điểm về các vấn đề của môn học.", TicketId = 1
            },
            new Quiz {
                Id = 10, QuizType = QuizType.Content3, Title = "Sau mỗi nội dung (phần, bài), giảng viên đã tóm tắt, hệ thống lại kiến thức đã giảng dạy, huấn luyện.", TicketId = 1
            },
            new Quiz {
                Id = 11, QuizType = QuizType.Content3, Title = "Sau mỗi buổi học, giảng viên đã hướng dẫn nội dung, phương pháp tự học cho học viên; sẵn sàng giải đáp những thắc mắc của học viên liên quan đến môn học.", TicketId = 1
            },
            new Quiz {
                Id = 12, QuizType = QuizType.Content3, Title = "Giảng viên đã kết hợp giữa truyền đạt kiến thức với giáo dục nhân cách, truyền thống cho người học.", TicketId = 1
            }
        };

        public static List<Statistical> Statisticals = new List<Statistical>();

        public static List<User> Users = new List<User>() {
            new User {
                Id = "admin", Name = "TanDC", Email = "tandc@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Admin, Password = "123"
            },
            new User {
                Id = "linhlp", Name = "LinhLP", Email = "linhlp@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123"
            },
            new User {
                Id = "hungnv", Name = "HungNV", Email = "hungnv@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123"
            }
        };
    }
}