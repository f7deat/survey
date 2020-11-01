using System;
using System.Collections.Generic;
using System.Linq;
using Survey.Entities;
using Survey.Enums;

namespace Survey.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SurveyDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var users = new List<User>() {
                new User {
                    Id = "admin", Name = "Hoàng Dương", Email = "tandc@defzone.net", Gender = true, DateOfBirth = DateTime.Now, UserType = UserType.Admin, Password = "123"
                },
                new User {
                    Id = "12A001", Name = "Nguyen Thùy Trang", Email = "tandc@defzone.net", Gender = false, DateOfBirth = DateTime.Now, UserType = UserType.Trainees, Password = "123", Department = "Phòng không không quân"
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            var departments = new List<Department>() {
                new Department {
                    Name = "Cách mạng xã hội chủ nghĩa"
                },
                new Department {
                    Name = "Cách mạng dân tộc chủ nghĩa nhân dân"
                }
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
            List<Quiz> quizzes = new List<Quiz>() {
            new Quiz {
                QuizType = QuizType.Content1, Title = "Giảng viên đã thông tin rõ mục tiêu, yêu cầu và nội dung môn học, trọng tâm, trọng điểm, tài liệu, vật chất của từng bài giảng. "
            },
            new Quiz {
                QuizType = QuizType.Content1, Title = "Giảng viên đã thông tin đầy đủ về kế hoạch giảng dạy, huấn luyện và tiêu chí đánh giá kết quả học tập."
            },
            new Quiz {
                QuizType = QuizType.Content1, Title = "Giảng viên đã chuẩn bị tốt các điều kiện để thực hành giảng bài, huấn luyện (giáo án, địa điểm, vật chất, trang thiết bị dạy học...)"
            },
            new Quiz {
                QuizType = QuizType.Content2, Title = "Giảng viên đã thực hiện đúng kế hoạch, nội dung bài giảng, huấn luyện đã được thông qua."
            },
            new Quiz {
                QuizType = QuizType.Content2, Title = "Nội dung giảng dạy đảm bảo tính Đảng, tính chính xác, khoa học, thiết thực, hữu ích và phù hợp nhận thức, năng lực của học viên."
            },
            new Quiz {
                QuizType = QuizType.Content2, Title = "Nội dung giảng dạy, huấn luyện đã cập nhật, đổi mới sát đúng với nội dung chương trình môn học."
            },
            new Quiz {
                QuizType = QuizType.Content3, Title = "Giảng viên có phương pháp truyền đạt rõ ràng, dễ hiểu, cuốn hút  tạo hứng khởi học tập học viên."
            },
            new Quiz {
                QuizType = QuizType.Content3, Title = "Giảng viên có kiến thức sâu rộng về môn học, kinh nghiệm công tác; có sự liên hệ thực tiễn phong phú, sinh động."
            },
            new Quiz {
                QuizType = QuizType.Content3, Title = "Phương pháp dạy học, huấn luyện của giảng viên đã góp phần phát triển tư duy sáng tạo của học viên, phát huy tính tự học, tự nghiên cứu; khuyến khích học viên nêu câu hỏi và bày tỏ quan điểm về các vấn đề của môn học."
            },
            new Quiz {
                QuizType = QuizType.Content3, Title = "Sau mỗi nội dung (phần, bài), giảng viên đã tóm tắt, hệ thống lại kiến thức đã giảng dạy, huấn luyện."
            },
            new Quiz {
                QuizType = QuizType.Content3, Title = "Sau mỗi buổi học, giảng viên đã hướng dẫn nội dung, phương pháp tự học cho học viên; sẵn sàng giải đáp những thắc mắc của học viên liên quan đến môn học."
            },
            new Quiz {
                QuizType = QuizType.Content3, Title = "Giảng viên đã kết hợp giữa truyền đạt kiến thức với giáo dục nhân cách, truyền thống cho người học."
            }
        };
        context.Quizzes.AddRange(quizzes);
        context.SaveChanges();
        }
    }
}