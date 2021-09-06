using System;
using System.Collections;
using System.Collections.Generic;

namespace TaskPad
{
    class Program
    {

        static int compare(Task x, Task y)
        {
            if (x.priority < y.priority)
                return -1;
            else
                return 1;
        }
        class Task
        {
            int _taskId;
            string _title;
            string _message;
            string _tag;
            int _priority;
            DateTime _stamp;
            public Task(int Id, string title, string message, string tag, int priority, DateTime stamp)
            {
                _taskId = Id;
                _title = title;
                _message = message;
                _tag = tag;
                _priority = priority;
                _stamp = stamp;
            }
            public int taskId
            {
                get { return _taskId; }
                set { _taskId = value; }
            }
            public string title
            {
                get { return _title; }
                set { _title = value; }
            }
            public string message
            {
                get { return _message; }
                set { _message = value; }
            }
            public string tag
            {
                get { return _tag; }
                set { _tag = value; }
            }
            public int priority
            {
                get { return _priority; }
                set { _priority = value; }
            }
            public DateTime stamp
            {
                get { return _stamp; }
                set { _stamp = value; }
            }

        }


        static void Main(string[] args)
        {

            try
            {
                Program p = new Program();
                List<Task> d = new List<Task>
            {
                {new Task(1, " Gym", "Get up and go", "pending", 4, DateTime.Now) },
                { new Task(2, " Exam", "You have to study maths and science", "pending", 5, DateTime.Now) },
                { new Task(3, " Money", "You have spent 10k this month", "pending", 3, DateTime.Now) }
            };

                var loopvar = true;
                while (loopvar)
                {
                    Console.WriteLine("************* Welcome ! *********************\n1. Create Task\n" +
                        "2. View Task by ID\n3. View All Tasks\n4. Edit Task\n5. Delete Task\n6. Exit");
                    Console.WriteLine("\nPlease select one of above option");
                    int inp = Convert.ToInt32(Console.ReadLine());

                    switch (inp)
                    {
                        case 1:
                            Console.WriteLine("\n Please enter title of task !");
                            string title = Console.ReadLine();
                            Console.WriteLine("\n Please enter the message !");
                            string message = Console.ReadLine();
                            string tag = "Pending";
                        Priority:
                            Console.WriteLine("\n Please enter priority between 1-5");
                            int priority = Convert.ToInt32(Console.ReadLine());
                            if (priority < 1 || priority > 5)
                            {
                                Console.WriteLine("\n Please enter a valid priority !");
                                goto Priority;
                            }
                            DateTime stamp = DateTime.Now;
                            d.Add(new Task(d.Count + 1, title, message, tag, priority, stamp));
                            Console.WriteLine("\n------ Task Added Successfully ! -------");
                            break;
                        case 2:
                        View:
                            Console.WriteLine("\n Please Enter the ID of Task !");
                            var _taskId = Convert.ToInt32(Console.ReadLine());
                            int res = d.FindIndex((x => x.taskId == _taskId));
                            if (res == -1)
                            {
                                Console.WriteLine("\n Please enter a valid ID !");
                                goto View;
                            }
                            Console.WriteLine("\n--------------------------------------------------------------");
                            Console.WriteLine("\n Title : " + d[res].title + "                        Date : " + d[res].stamp);
                            Console.WriteLine("\n Id : " + d[res].taskId + "                                Priority : " + d[res].priority);
                            Console.WriteLine("\n Message : \n " + d[res].message);
                            Console.WriteLine("\n--------------------------------------------------------------");
                            break;

                        case 3:
                            d.Sort(compare);
                            foreach (var item in d)
                            {
                                Console.WriteLine("\n--------------------------------------------------------------");
                                Console.WriteLine("\n Title : " + item.title + "                        Date : " + item.stamp);
                                Console.WriteLine("\n Id : " + item.taskId + "                                Priority : " + item.priority);
                                Console.WriteLine("\n Message : \n " + item.message);
                                Console.WriteLine("\n--------------------------------------------------------------");
                            }

                            break;
                        case 4:
                        Edit:
                            Console.WriteLine("\n Please Enter the ID of Task !");
                            var _taskID = Convert.ToInt32(Console.ReadLine());
                            int final = d.FindIndex((x => x.taskId == _taskID));
                            if (final == -1)
                            {
                                Console.WriteLine("\n Please enter a valid ID !");
                                goto Edit;
                            }
                            var loop = true;
                            string Title = d[final].title;
                            string Message = d[final].message;
                            string Tag = d[final].tag;
                            int Priority = d[final].priority;
                            DateTime Stamp = d[final].stamp;
                            while (loop)
                            {
                                Console.WriteLine("\n Please enter the number of field you want to edit.\n 1. Title\n 2. Message" +
                                    "\n 3. Tag\n 4. Priority \n 5. Exit");
                                int input = Convert.ToInt32(Console.ReadLine());

                                switch (input)
                                {
                                    case 1:
                                        Console.WriteLine("\n Please enter the Title");
                                        Title = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("\n Please enter the Message");
                                        Message = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.WriteLine("\n Please enter the tag");
                                        Tag = Console.ReadLine();
                                        break;
                                    case 4:
                                        Console.WriteLine("\n Please enter the Priority");
                                        Priority = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    case 5:
                                        loop = false;
                                        break;
                                }
                            }
                            d.Insert(final, new Task(final, Title, Message, Tag, Priority, Stamp));
                            Console.WriteLine("\n Successfully Modified !");
                            break;

                        case 5:
                        Delete:
                            Console.WriteLine("\n Please Enter the ID of Task !");
                            var taskId = Convert.ToInt32(Console.ReadLine());
                            int result = d.FindIndex((x => x.taskId == taskId));
                            if (result == -1)
                            {
                                Console.WriteLine("\n Please enter a valid ID !");
                                goto Delete;
                            }
                            d.RemoveAt(result + 1);
                            Console.WriteLine("\n Successfully Deleted !");
                            break;

                        case 6:
                            loopvar = false;
                            break;

                    }



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
