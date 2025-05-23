﻿using NinetiesTV;

List<Show> shows = DataLoader.GetShows();

ResultPrinter.Print("All Names", Names(shows));
ResultPrinter.Print("Alphabetical Names", NamesAlphabetically(shows));
ResultPrinter.Print("Ordered by Popularity", ShowsByPopularity(shows));
ResultPrinter.Print("Shows with an '&'", ShowsWithAmpersand(shows));
ResultPrinter.Print("Latest year a show aired", MostRecentYear(shows));
ResultPrinter.Print("Average Rating", AverageRating(shows));
ResultPrinter.Print("Shows only aired in the 90s", OnlyInNineties(shows));
ResultPrinter.Print("Top Three Shows", TopThreeByRating(shows));
ResultPrinter.Print("Shows starting with 'The'", TheShows(shows));
ResultPrinter.Print("All But the Worst", AllButWorst(shows));
ResultPrinter.Print("Shows with Few Episodes", FewEpisodes(shows));
ResultPrinter.Print("Shows Sorted By Duration", ShowsByDuration(shows));
ResultPrinter.Print("Comedies Sorted By Rating", ComediesByRating(shows));
ResultPrinter.Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
ResultPrinter.Print("Most Episodes", MostEpisodes(shows));
ResultPrinter.Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
ResultPrinter.Print("Best Drama", BestDrama(shows));
ResultPrinter.Print("All But Best Drama", AllButBestDrama(shows));
ResultPrinter.Print("Good Crime Shows", GoodCrimeShows(shows));
ResultPrinter.Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
ResultPrinter.Print("Most Words in Title", WordieastName(shows));
ResultPrinter.Print("All Names", AllNamesWithCommas(shows));
ResultPrinter.Print("All Names with And", AllNamesWithCommasPlsAnd(shows));

/**************************************************************************************************
    The Exercises

    Above each method listed below, you'll find a comment that describes what the method should do.
    Your task is to write the appropriate LINQ code to make each method return the correct result.

**************************************************************************************************/

// 1. Return a list of each of show names.
static List<string> Names(List<Show> shows)
{
    return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
}

// 2. Return a list of show names ordered alphabetically.
static List<string> NamesAlphabetically(List<Show> shows)
{
    return shows
        .OrderBy(show => show.Name)
        .Select(show => show.Name)
        .ToList();
}


// 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
static List<Show> ShowsByPopularity(List<Show> shows)
{
    return shows
        .OrderByDescending(show => show.ImdbRating)
        .ToList();
}


// 4. Return a list of shows whose title contains an & character.
static List<Show> ShowsWithAmpersand(List<Show> shows)
{
    return shows
        .Where(show => show.Name.Contains("&"))
        .ToList();
}

// 5. Return the most recent year that any of the shows aired.
static int MostRecentYear(List<Show> shows)
{
    return shows.Max(show => show.EndYear);
}

// 6. Return the average IMDB rating for all the shows.
static double AverageRating(List<Show> shows)
{
    return shows.Average(show => show.ImdbRating);
}

// 7. Return the shows that started and ended in the 90s.
static List<Show> OnlyInNineties(List<Show> shows)
{
    return shows
        .Where(show => show.StartYear >= 1990 && show.EndYear < 2000)
        .ToList();
}

// 8. Return the top three highest rated shows.
static List<Show> TopThreeByRating(List<Show> shows)
{
    return shows
        .OrderByDescending(show => show.ImdbRating)
        .Take(3)
        .ToList();
}

// 9. Return the shows whose name starts with the word "The".
static List<Show> TheShows(List<Show> shows)
{
    return shows
        .Where(show => show.Name.StartsWith("The"))
        .ToList();
}

// 10. Return all shows except for the lowest rated show.
static List<Show> AllButWorst(List<Show> shows)
{
    double minRating = shows.Min(show => show.ImdbRating);
    return shows
        .Where(show => show.ImdbRating != minRating)
        .ToList();
}

// 11. Return the names of the shows that had fewer than 100 episodes.
static List<string> FewEpisodes(List<Show> shows)
{
    return shows
        .Where(show => show.EpisodeCount < 100)
        .Select(show => show.Name)
        .ToList();
}

// 12. Return all shows ordered by the number of years on air.
//     Assume the number of years between the start and end years is the number of years the show was on.
static List<Show> ShowsByDuration(List<Show> shows)
{
    return shows
        .OrderByDescending(show => show.EndYear - show.StartYear)
        .ToList();
}

// 13. Return the names of the comedy shows sorted by IMDB rating.
static List<string> ComediesByRating(List<Show> shows)
{
    return shows
        .Where(show => show.Genres.Contains("Comedy"))
        .OrderByDescending(show => show.ImdbRating)
        .Select(show => show.Name)
        .ToList();
}

// 14. Return the shows with more than one genre ordered by their starting year.
static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
{
    return shows
        .Where(show => show.Genres.Count > 1)
        .OrderBy(show => show.StartYear)
        .ToList();
}

// 15. Return the show with the most episodes.
static Show MostEpisodes(List<Show> shows)
{
    return shows
        .OrderByDescending(show => show.EpisodeCount)
        .First();
}

// 16. Order the shows by their ending year then return the first 
//     show that ended on or after the year 2000.
static Show EndedFirstAfterTheMillennium(List<Show> shows)
{
    return shows
        .Where(show => show.EndYear >= 2000)
        .OrderBy(show => show.EndYear)
        .First();
}

// 17. Order the shows by rating (highest first) 
//     and return the first show with genre of drama.
static Show BestDrama(List<Show> shows)
{
    return shows
        .Where(show => show.Genres.Contains("Drama"))
        .OrderByDescending(show => show.ImdbRating)
        .First();
}

// 18. Return all dramas except for the highest rated.
static List<Show> AllButBestDrama(List<Show> shows)
{
    var bestDrama = BestDrama(shows); // reuse earlier logic
    return shows
        .Where(show => show.Genres.Contains("Drama") && show != bestDrama)
        .ToList();
}

// 19. Return the number of crime shows with an IMDB rating greater than 7.0.
static int GoodCrimeShows(List<Show> shows)
{
    return shows
        .Count(show => show.Genres.Contains("Crime") && show.ImdbRating > 7.0);
}

// 20. Return the first show that ran for more than 10 years 
//     with an IMDB rating of less than 8.0 ordered alphabetically.
static Show FirstLongRunningTopRated(List<Show> shows)
{
    return shows
        .Where(show => (show.EndYear - show.StartYear) > 10 && show.ImdbRating < 8.0)
        .OrderBy(show => show.Name)
        .FirstOrDefault();
}

// 21. Return the show with the most words in the name.
static Show WordieastName(List<Show> shows)
{
    return shows
        .OrderByDescending(show => show.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length)
        .First();
}

// 22. Return the names of all shows as a single string seperated by a comma and a space.
static string AllNamesWithCommas(List<Show> shows)
{
    return string.Join(", ", shows.Select(show => show.Name));
}

// 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
static string AllNamesWithCommasPlsAnd(List<Show> shows)
{
    var names = shows.Select(show => show.Name).ToList();

    if (names.Count == 0) return "";
    if (names.Count == 1) return names[0];

    var allButLastTwo = names.Take(names.Count - 2);
    var lastTwo = names.Skip(names.Count - 2).ToList();

    return string.Join(", ", allButLastTwo)
        + (allButLastTwo.Any() ? ", " : "")
        + string.Join(" and ", lastTwo);
}


/**************************************************************************************************
    CHALLENGES

    These challenges are very difficult and may require you to research LINQ methods that we haven't
    talked about. Such as:

    GroupBy()
    SelectMany()
    Count()

**************************************************************************************************/

// 1. Return the genres of the shows that started in the 80s.
// 2. Print a unique list of geners.
// 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
// 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
// 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.



/**************************************************************************************************
 There is no code to write or change below this line, but you might want to read it.
**************************************************************************************************/
class ResultPrinter
{
    public static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

    public static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

    public static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

    public static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

    public static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

    public static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

    public static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
        Console.WriteLine("--------------------------------------------");
    }
}