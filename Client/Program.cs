using Client;
using System.Linq;
using System.Net.Http.Json;
using System.Collections.Generic;


HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7019");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


//Checking if server is online
Console.WriteLine("Check if server is online. Press any key to continue");
Console.ReadLine();

try
{
    var responseServerStatus = client.GetAsync("api/categories");
    Console.WriteLine("Server is online");
}
catch (HttpRequestException exception)
{

    throw new Exception(exception.Message);
}

Console.WriteLine(Environment.NewLine);
Console.WriteLine("Want to have a look in the categories of our questions? Y/N");
string userResponse = Console.ReadLine();



if (userResponse == "Y")
{
    HttpResponseMessage response = await client.GetAsync("api/categories");
    response.EnsureSuccessStatusCode();

    if (response.IsSuccessStatusCode)
    {
        //Getting all categories

        Console.WriteLine(Environment.NewLine);
        var categories = await response.Content.ReadFromJsonAsync<IEnumerable<Client.CategoryDto>>();

        Console.Write(String.Join(',', categories.Select(category => category.Name)));

        Console.Write(Environment.NewLine);

        Console.WriteLine("Choose a category or multiple categories which you would like to play with:");

        string clientInputCategory = Console.ReadLine();

        List<string> clientInputCategories = clientInputCategory.Split(", ").ToList();

        int categoryId = clientInputCategories.IndexOf(clientInputCategory);

        //Choosing game mode
        Console.WriteLine("Choose game mode: Normal or Survival");
        userResponse = Console.ReadLine();

        if (userResponse == "Normal")
        {
            response = await client.GetAsync("api/ranks");
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Choose dificulty level:");

            if (response.IsSuccessStatusCode)
            {

                //Getting all difficulties

                var ranks = await response.Content.ReadFromJsonAsync<IEnumerable<Client.RankDto>>();
                Console.Write(String.Join(',', ranks.Select(rank => rank.Name)));
                Console.WriteLine(Environment.NewLine);
                userResponse = Console.ReadLine();
                int score = 0;
                int correctAnswers = 0;

                if (userResponse == "Easy")
                {
                    response = await client.GetAsync("api/questions");
                    if (response.IsSuccessStatusCode)
                    {
                        var questions = await response.Content.ReadFromJsonAsync<IEnumerable<Client.QuestionDto>>();
                        var questionsList = questions.Where(question => question.CategoryId == categoryId
                   && question.GetRankName() == userResponse).OrderBy(a => Guid.NewGuid()).Take(10);
                        

                        foreach (var question in questionsList)
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(question.Text);
                            Console.Write(Environment.NewLine);

                            response = await client.GetAsync("api/answers");
                            if (response.IsSuccessStatusCode)
                            {
                                var answers = await response.Content.ReadFromJsonAsync<IEnumerable<Client.AnswersDto>>();
                                var answersList = answers.Where(answer => answer.QuestionId == question.Id);

                                Dictionary<string, AnswersDto> answerDictionary = new Dictionary<string, AnswersDto>();
                                answerDictionary.Add("a", answersList.ElementAt(0));
                                answerDictionary.Add("b", answersList.ElementAt(1));
                                answerDictionary.Add("c", answersList.ElementAt(2));
                                answerDictionary.Add("d", answersList.ElementAt(3));

                                foreach (KeyValuePair<string, AnswersDto> answer in answerDictionary)
                                {
                                    Console.WriteLine(answer.Key + " " + answer.Value.Text);

                                }

                                Console.WriteLine("Choose an answer:");
                                string userAnswersInput = Console.ReadLine();

                                if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect)
                                {
                                    correctAnswers++;
                                    score++;
                                }
                                Console.ReadLine();

                            }
                            else
                            {
                                Console.WriteLine("No results");
                            }

                        }
                        Console.WriteLine("Correct answers: " + correctAnswers);
                        Console.WriteLine("Wrong answers: " + (10 - correctAnswers));
                        Console.WriteLine("Total score: " + (score) + "/10");


                    }
                    else
                    {
                        Console.WriteLine("No results");
                    }
                }
                else if (userResponse == "Medium")
                {
                    response = await client.GetAsync("api/questions");
                    if (response.IsSuccessStatusCode)
                    {
                        var questions = await response.Content.ReadFromJsonAsync<IEnumerable<Client.QuestionDto>>();
                        var questionsList = questions.Where(question => question.CategoryId == categoryId
                   && question.GetRankName() == userResponse).OrderBy(a => Guid.NewGuid()).Take(10);


                        foreach (var question in questionsList)
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(question.Text);
                            Console.Write(Environment.NewLine);

                            response = await client.GetAsync("api/answers");
                            if (response.IsSuccessStatusCode)
                            {
                                var answers = await response.Content.ReadFromJsonAsync<IEnumerable<Client.AnswersDto>>();
                                var answersList = answers.Where(answer => answer.QuestionId == question.Id);

                                Dictionary<string, AnswersDto> answerDictionary = new Dictionary<string, AnswersDto>();
                                answerDictionary.Add("a", answersList.ElementAt(0));
                                answerDictionary.Add("b", answersList.ElementAt(1));
                                answerDictionary.Add("c", answersList.ElementAt(2));
                                answerDictionary.Add("d", answersList.ElementAt(3));

                                foreach (KeyValuePair<string, AnswersDto> answer in answerDictionary)
                                {
                                    Console.WriteLine(answer.Key + " " + answer.Value.Text);

                                }

                                Console.WriteLine("Choose an answer:");
                                string userAnswersInput = Console.ReadLine();

                                if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect)
                                {
                                    correctAnswers++;
                                    score += 2;
                                }
                                Console.ReadLine();

                            }
                            else
                            {
                                Console.WriteLine("No results");
                            }

                        }
                        Console.WriteLine("Correct answers: " + correctAnswers);
                        Console.WriteLine("Wrong answers: " + (10 - correctAnswers));
                        Console.WriteLine("Total score: " + (20 - score) + "/20");
                    }
                    else
                    {
                        Console.WriteLine("No results");
                    }
                }
                else if (userResponse == "Hard")
                {
                    response = await client.GetAsync("api/questions");
                    if (response.IsSuccessStatusCode)
                    {
                        var questions = await response.Content.ReadFromJsonAsync<IEnumerable<Client.QuestionDto>>();
                        var questionsList = questions.Where(question => question.CategoryId == categoryId
                   && question.GetRankName() == userResponse).OrderBy(a => Guid.NewGuid()).Take(10);


                        foreach (var question in questionsList)
                        {
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(question.Text);
                            Console.Write(Environment.NewLine);

                            response = await client.GetAsync("api/answers");
                            if (response.IsSuccessStatusCode)
                            {
                                var answers = await response.Content.ReadFromJsonAsync<IEnumerable<Client.AnswersDto>>();
                                var answersList = answers.Where(answer => answer.QuestionId == question.Id);

                                Dictionary<string, AnswersDto> answerDictionary = new Dictionary<string, AnswersDto>();
                                answerDictionary.Add("a", answersList.ElementAt(0));
                                answerDictionary.Add("b", answersList.ElementAt(1));
                                answerDictionary.Add("c", answersList.ElementAt(2));
                                answerDictionary.Add("d", answersList.ElementAt(3));

                                foreach (KeyValuePair<string, AnswersDto> answer in answerDictionary)
                                {
                                    Console.WriteLine(answer.Key + " " + answer.Value.Text);

                                }

                                Console.WriteLine("Choose an answer:");
                                string userAnswersInput = Console.ReadLine();

                                if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect)
                                {
                                    correctAnswers++;
                                    score += 3;
                                }
                                Console.ReadLine();

                            }
                            else
                            {
                                Console.WriteLine("No results");
                            }

                        }
                        Console.WriteLine("Correct answers: " + correctAnswers);
                        Console.WriteLine("Wrong answers: " + (10 - correctAnswers));
                        Console.WriteLine("Total score: " + (30 - score) + "/30");
                    }
                    else
                    {
                        Console.WriteLine("No results");
                    }
                }
            }
            else
            {
                Console.WriteLine("No results");
            }

        }
        else if (userResponse == "Survival")
        {
            response = await client.GetAsync("api/questions");
            if (response.IsSuccessStatusCode)
            {
                int score = 0;
                int correctAnswers = 0;

                var questions = await response.Content.ReadFromJsonAsync<IEnumerable<Client.QuestionDto>>();
                var questionsList1 = questions.Where(question => question.CategoryId == 0 && question.RankId == 0).Take(2);
                var questionsList2 = questions.Where(question => question.CategoryId == 0 && question.RankId == 1).Take(2);
                var questionsList3 = questions.Where(question => question.CategoryId == 0 && question.RankId == 2).Take(2);
                var questionsList4 = questions.Where(question => question.CategoryId == 1 && question.RankId == 0).Take(2);
                var questionsList5 = questions.Where(question => question.CategoryId == 1 && question.RankId == 1).Take(2);
                var questionsList6 = questions.Where(question => question.CategoryId == 1 && question.RankId == 2).Take(2);
                var questionsList7 = questions.Where(question => question.CategoryId == 2 && question.RankId == 0).Take(2);
                var questionsList8 = questions.Where(question => question.CategoryId == 2 && question.RankId == 1).Take(2);
                var questionsList9 = questions.Where(question => question.CategoryId == 2 && question.RankId == 2).Take(2);

                var questionsList = questionsList1.Concat(questionsList4).Concat(questionsList7).
                    Concat(questionsList2).Concat(questionsList5).Concat(questionsList8).
                    Concat(questionsList3).Concat(questionsList6).Concat(questionsList9).ToList();

                foreach (var question in questionsList)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(question.Text);
                    Console.Write(Environment.NewLine);

                    response = await client.GetAsync("api/answers");
                    if (response.IsSuccessStatusCode)
                    {
                        var answers = await response.Content.ReadFromJsonAsync<IEnumerable<Client.AnswersDto>>();
                        var answersList = answers.Where(answer => answer.QuestionId == question.Id);

                        Dictionary<string, AnswersDto> answerDictionary = new Dictionary<string, AnswersDto>();
                        answerDictionary.Add("a", answersList.ElementAt(0));
                        answerDictionary.Add("b", answersList.ElementAt(1));
                        answerDictionary.Add("c", answersList.ElementAt(2));
                        answerDictionary.Add("d", answersList.ElementAt(3));

                        foreach (KeyValuePair<string, AnswersDto> answer in answerDictionary)
                        {
                            Console.WriteLine(answer.Key + " " + answer.Value.Text);

                        }

                        Console.WriteLine("Choose an answer:");
                        string userAnswersInput = Console.ReadLine();

                        if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect == true && question.RankId == 0)
                        {
                            score++;
                            correctAnswers++;
                        }
                        else if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect == true && question.RankId == 1)
                        {
                            score += 1;
                            correctAnswers++;
                        }
                        else if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect == true && question.RankId == 2)
                        {
                            score += 2;
                            correctAnswers++;
                        }
                        else if (answerDictionary.GetValueOrDefault(userAnswersInput).IsCorrect == false)
                        {
                            Console.WriteLine("Correct answers: " + correctAnswers);
                            Console.WriteLine("Final score: " + (36 - score));
                        }

                        Console.ReadLine();

                    }
                    else
                    {
                        Console.WriteLine("No results");
                    }

                }

                Console.WriteLine("Correct answers: " + correctAnswers);
                Console.WriteLine("Final score: " + (36-score));

            }

        }

    }
    else
    {
        Console.WriteLine("No results");
    }
}
else if (userResponse == "N")
{
    Console.WriteLine("Maybe you aren't in a mood for trivia after all...");
}
else
{
    Console.WriteLine("Follow the required response format!");
}



    

