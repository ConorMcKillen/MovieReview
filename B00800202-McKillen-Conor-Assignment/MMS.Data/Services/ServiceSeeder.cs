using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.Data.Models;

namespace MMS.Data.Services
{
    public static class ServiceSeeder
    {
        // use this class to seed the database with dummy
        // test data using an IMovieService

        public static void Seed(IMovieService svc)
        {
            svc.Initialise();

            // Create and add all the movies to the seeder

            var m1 = new Movie()
            {
                Title = "The Matrix",
                Budget = 6300000000,
                Year = 2001,
                Cast = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, Joe Pantoliano",
                Director = "Lilly Wachowski, Lana Wachowski",
                Duration = 136,
                Genre = Genre.Action,
                Plot = "Set in the 22nd century, The Matrix tells the story of a computer hacker who joins a group of underground insurgents fighting the vast and powerful computers who now rule the earth",
                PosterUrl = "https://www.themoviedb.org/t/p/original/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg"
            };

            // Add movie

            svc.AddMovie(m1);
            
            

            var m2 = new Movie()
            {
                Title = "Killer Klowns From Outer Space",
                Budget = 2000000.00,
                Year = 1988,
                Cast = "Grant Cramer, Suzanne Snyder, John Allen Nelson, John Vernon, Royal Dano",
                Director = "Stephen Chiodo",
                Duration = 88,
                Genre = Genre.Horror,
                Plot = "Aliens disguised as clowns crash land on Earth in a rural town to capture unsuspecting victims in cotton candy cocoons for later consumption.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/tqq4acpAOUyvx0e7ZlwLEY5aGJQ.jpg"
            };

            svc.AddMovie(m2);

            var m3 = new Movie()
            {
                Title = "The Founder",
                Budget = 25000000.00,
                Year = 2016,
                Cast = "Michael Keaton, Nick Offerman, John Carrol Lynch, Linda Cardellini, Patrick Wilson",
                Director = "John Lee Hancock",
                Duration = 71,
                Genre = Genre.Drama,
                Plot = "The true story of how Ray Kroc, a salesman from Illinois, met Mac and Dick McDonald, who were running a burger operation in 1950s Southern California. Kroc was impressed by the brothers’ speedy system of making the food and saw franchise potential. He maneuvered himself into a position to be able to pull the company from the brothers and create a billion-dollar empire.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/2ddngC5GGYpUPu7um3wKZ41sA7m.jpg"
            };

            svc.AddMovie(m3);

            var m4 = new Movie()
            {
                Title = "They Live",
                Budget = 4000000.00,
                Year = 1988,
                Cast = "Roddy Piper, Keith David, Meg Foster, George Buck Flower, Peter Jason",
                Director = "John Carpenter",
                Duration = 94,
                Genre = Genre.SciFi,
                Plot = "Nada, a wanderer without meaning in his life, discovers a pair of sunglasses capable of showing the world the way it truly is. As he walks the streets of Los Angeles, Nada notices that both the media and the government are comprised of subliminal messages meant to keep the population subdued, and that most of the social elite are skull-faced aliens bent on world domination. With this shocking discovery, Nada fights to free humanity from the mind-controlling aliens.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/s0tLTFQQ8m6JQAUuw9rZqG4OCLv.jpg"
            };

            svc.AddMovie(m4);

            var m5 = new Movie()
            {
                Title = "El Camino: A Breaking Bad Movie",
                Budget = 6000000.00,
                Year = 2019,
                Cast = "Aaron Paul, Jesse Plemons, Charles Baker, Matt Jones, Scott McArthur, Robert Forster, Jonathan Banks",
                Director = "Vince Gilligan",
                Duration = 123,
                Genre = Genre.Crime,
                Plot = "In the wake of his dramatic escape from captivity, Jesse Pinkman must come to terms with his past in order to forge some kind of future.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/ePXuKdXZuJx8hHMNr2yM4jY2L7Z.jpg"
            };

            svc.AddMovie(m5);

            var m6 = new Movie()
            {
                Title = "Easy Rider",
                Budget = 360000.00,
                Year = 1969,
                Cast = "Peter Fonda, Dennis Hopper, Antonio Mendoza, Phil Spector",
                Director = "Dennis Hopper",
                Duration = 95,
                Genre = Genre.Drama,
                Plot = "A cross-country trip to sell drugs puts two hippie bikers on a collision course with small-town prejudices.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/mmGEB6ly9OG8SYVfvAoa6QqHNvN.jpg"
            };

            svc.AddMovie(m6);

            var m7 = new Movie()
            {
                Title = "Airheads",
                Budget = 11200000.00,
                Year = 1994,
                Cast = "Brendan Frazer, Steve Buscemi, Adam Sandler, Chris Faley, Judd Nelson, Michael McKean",
                Director = "Michael Lehmann",
                Duration = 92,
                Genre = Genre.Comedy,
                Plot = "The Lone Rangers have heavy-metal dreams and a single demo tape they can't get anyone to play. The solution: Hijack an AM rock station and hold the deejays hostage until they agree to broadcast the band's tape.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/jCgVjzXnCcckfeWxzR7U9TOFtSB.jpg"
            };

            svc.AddMovie(m7);

            var m8 = new Movie()
            {
                Title = "The Punisher",
                Budget = 33000000.00,
                Year = 2004,
                Cast = "Thomas Jane, John Travolta, Will Patton, Roy Scheider Laura Harding",
                Director = "Jonathan Hensleigh",
                Duration = 124,
                Genre = Genre.Action,
                Plot = "There is no justice, there is only revenge.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/dxzZGQl9uHEnnGaQ0rN3oFkeO4z.jpg"
            };

            svc.AddMovie(m8);

            var m9 = new Movie()
            {
                Title = "Rambo: First Blood",
                Budget = 15000000.00,
                Year = 1982,
                Cast = "Sylvester Stallone, Richard Crenna, Brian Dennehy, Bill McKinney, Jack Starrett",
                Director = "Ted Kotcheff",
                Duration = 93,
                Genre = Genre.Action,
                Plot = "When former Green Beret John Rambo is harassed by local law enforcement and arrested for vagrancy, the Vietnam vet snaps, runs for the hills and rat-a-tat-tats his way into the action-movie hall of fame. Hounded by a relentless sheriff, Rambo employs heavy-handed guerilla tactics to shake the cops off his tail.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/fVamGe8rfEQUrMbzumL1t0DslCA.jpg"
            };

            svc.AddMovie(m9);

            var m10 = new Movie()
            {
                Title = "Crossroads",
                Budget = 5839000.00,
                Year = 1986,
                Cast = "Ralph Macchio, Joe Seneca, Jami Gertz, Joe Morton, Robert Judd, Steve Vai",
                Director = "Walter Hill",
                Duration = 99,
                Genre = Genre.Music,
                Plot = "A wanna-be blues guitar virtuoso seeks a long-lost song by legendary musician, Robert Johnson.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/jSx2NtVcy3PJST6YHefNdxw5euZ.jpg"
            };

            svc.AddMovie(m10);

            var m11 = new Movie()
            {
                Title = "Apocalypse Now",
                Budget = 31500000.00,
                Year = 1979,
                Cast = "Martin Sheen, Marlon Brando, Robert Duvall, Frederic Forrest, Laurence Fishburne",
                Director = "Francis Ford Coppola",
                Duration = 147,
                Genre = Genre.War,
                Plot = "At the height of the Vietnam war, Captain Benjamin Willard is sent on a dangerous mission that, officially, \"does not exist, nor will it ever exist.\" His goal is to locate - and eliminate - a mysterious Green Beret Colonel named Walter Kurtz, who has been leading his personal army on illegal guerrilla missions into enemy territory.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/7qm2eOuOaR7mpjpIciQu1dLlnWV.jpg"
            };

            svc.AddMovie(m11);

            var m12 = new Movie()
            {
                Title = "Once Upon a Time... in Hollywood",
                Budget = 95000000.00,
                Year = 2019,
                Cast = "Leonardo DiCaprio, Brad Pitt, Margot Robbie, Emile Hirsch",
                Director = "Quentin Tarantino",
                Duration = 162,
                Genre = Genre.Drama,
                Plot = "Los Angeles, 1969. TV star Rick Dalton, a struggling actor specializing in westerns, and stuntman Cliff Booth, his best friend, try to survive in a constantly changing movie industry. Dalton is the neighbor of the young and promising actress and model Sharon Tate, who has just married the prestigious Polish director Roman Polanski…",
                PosterUrl = "https://www.themoviedb.org/t/p/original/8j58iEBw9pOXFD2L0nt0ZXeHviB.jpg"
            };

            svc.AddMovie(m12);

            var m13 = new Movie()
            {
                Title = "The Warriors",
                Budget = 4000000.00,
                Year = 1979,
                Cast = "Michael Beck, James Remar, David Patrick Kelly, Dorsey Wright, David Harris",
                Director = "Walter Hill",
                Duration = 93,
                Genre = Genre.Action,
                Plot = "Prominent gang leader Cyrus calls a meeting of New York's gangs to set aside their turf wars and take over the city. At the meeting, a rival leader kills Cyrus, but a Coney Island gang called the Warriors is wrongly blamed for Cyrus' death. Before you know it, the cops and every gangbanger in town is hot on the Warriors' trail.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/fCDXAJcPvpsMd5CL1kBKkkNGW3X.jpg"
            };

            svc.AddMovie(m13);

            var m14 = new Movie()
            {
                Title = "The Big Lebowski",
                Budget = 15000000.00,
                Year = 1998,
                Cast = "Jeff Bridges, John Goodman, Steve Buscemi, Julianne Moore, Phillip Seymour Hoffman",
                Director = "Joel Coen",
                Duration = 117,
                Genre = Genre.Comedy,
                Plot = "Jeffrey 'The Dude' Lebowski, a Los Angeles slacker who only wants to bowl and drink White Russians, is mistaken for another Jeffrey Lebowski, a wheelchair-bound millionaire, and finds himself dragged into a strange series of events involving nihilists, adult film producers, ferrets, errant toes, and large sums of money.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/YFRZ7m5Nhc144chYmtP9o2zvXe.jpg"
            };

            svc.AddMovie(m14);

            var m15 = new Movie()
            {
                Title = "Se7en",
                Budget = 33000000.00,
                Year = 1995,
                Cast = "Brad Pitt, Morgan Freeman, Gwyneth Paltrow, R. Lee Ermey, John C. McGinley",
                Director = "David Fincher",
                Duration = 127,
                Genre = Genre.Crime,
                Plot = "Two homicide detectives are on a desperate hunt for a serial killer whose crimes are based on the \"seven deadly sins\" in this dark and haunting film that takes viewers from the tortured remains of one victim to the next. The seasoned Det. Sommerset researches each sin in an effort to get inside the killer's mind, while his novice partner, Mills, scoffs at his efforts to unravel the case.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/69Sns8WoET6CfaYlIkHbla4l7nC.jpg"
            };

            svc.AddMovie(m15);

            var m16 = new Movie()
            {
                Title = "Batman Forever",
                Budget = 100000000.00,
                Year = 1995,
                Cast = "Val Kilmer, Tommy Lee Jones, Jim Carrey, Nicole Kidman, Chris O'Donnell",
                Director = "Joel Schumacher",
                Duration = 121,
                Genre = Genre.Action,
                Plot = "Batman must battle a disfigured district attorney and a disgruntled former employee with help from an amorous psychologist and a young circus acrobat.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/mzzNBVwTiiY94xAXDMWJpNPW2US.jpg"
            };

            svc.AddMovie(m16);

            var m17 = new Movie()
            {
                Title = "Spider-Man: Into the Spider-Verse",
                Budget = 90000000.00,
                Year = 2018,
                Cast = "Shameik Moore, Jake Johnson, Hailee Steinfeld, Mahershala Ali,  Brian Tyree Henry, Lily Tomlin",
                Director = "Rodney Rothman",
                Duration = 117,
                Genre = Genre.SciFi,
                Plot = "Miles Morales is juggling his life between being a high school student and being a spider-man. When Wilson \"Kingpin\" Fisk uses a super collider, others from across the Spider-Verse are transported to this dimension.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/3cZn1k8x0bikrDKEy9ZKJ6Vdj30.jpg"
            };

            svc.AddMovie(m17);

            var m18 = new Movie()
            {
                Title = "The Last King of Scotland",
                Budget = 6000000.00,
                Year = 2006,
                Cast = "Forest Whitaker, James McAvoy, Simon McBurney, Gillian Anderson, Kerry Washington",
                Director = "Kevin MacDonald",
                Duration = 123,
                Genre = Genre.Drama,
                Plot = "Young Scottish doctor, Nicholas Garrigan decides it's time for an adventure after he finishes his formal education, so he decides to try his luck in Uganda, and arrives during the downfall of President Obote. General Idi Amin comes to power and asks Garrigan to become his personal doctor.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/n1CgN2mS7RSxHhv2R1DdisYDvT6.jpg"
            };

            svc.AddMovie(m18);

            var m19 = new Movie()
            {
                Title = "Paul Blart: Mall Cop",
                Budget = 26000000.00,
                Year = 2009,
                Cast = "Kevin James, Keir O'Donnell, Jayma Mays, Bobby Cannavale, Shirley Knight, Raini Rodriguez",
                Director = "Steve Carr",
                Duration = 91,
                Genre = Genre.Family,
                Plot = "Mild-mannered Paul Blart has always had huge dreams of becoming a State Trooper. Until then, he patrols the local mall as a security guard. With his closely cropped moustache, personal transporter and gung-ho attitude, only Blart seems to take his job seriously. All that changes when a team of thugs raids the mall and takes hostages. Untrained, unarmed and a super-size target, Blart has to become a real cop to save the day.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/srjOOLxFuvpyCywR5Wu2EY9pGF.jpg"
            };

            svc.AddMovie(m19);

            var m20 = new Movie()
            {
                Title = "Red Dawn",
                Budget = 17000000.00,
                Year = 1984,
                Cast = "Patrick Swayze, Charlie Sheen, C. Thomas Howell, Lea Thompson, Darren Dalton",
                Director = "John Milius",
                Duration = 114,
                Genre = Genre.Action,
                Plot = "It is the dawn of World War III. In mid-western America, a group of teenagers band together to defend their town—and their country—from invading Soviet forces.",
                PosterUrl = "https://www.themoviedb.org/t/p/original/hHIjv3N80ii3UsOgxToZ4ODIt2n.jpg"
            };

            svc.AddMovie(m20);


            // Create and add reviews to the seeder



            var r1 = new Review()
            {
                MovieId = m1.Id,
                Name = "GeekMasher",
                CreatedOn = new DateTime(2013, 03, 15),
                Comment = "The Martix is a great example of a movie that will live for ever or a very log time. The story and concept are out of this world. Keanu Reeves plays his role with utter brilliance, the cast was very well put together and the graphics are still to this day amazing. All in all one of the best movies of all time.",
                Rating = 9,
            };

            svc.AddReview(r1);

            var r2 = new Review()
            {
                MovieId = m2.Id,
                Name = "cricketbat",
                CreatedOn = new DateTime(2020, 10, 13),
                Comment = "Killer Klowns from Outer Space knows what it is-a silly B-movie featuring goofy gimmicks and a hokey story. The actors also seem to be in on the joke, which means none of them are taking it seriously, either. This movie is an enjoyable, ridiculous ride and features some impressive visual effects for having such a small budget. Killer Klowns is kind of kool.",
                Rating = 7
            };

            svc.AddReview(r2);

            var r3 = new Review()
            {
                MovieId = m3.Id,
                Name = "Reno",
                CreatedOn = new DateTime(2017, 10, 09),
                Comment = "I anticipated another inspiring biopic about a man who built an empire. That's partially true, because this was inspired by the right kind of wrong thing. I mean it was not actually about the McDonalds' story, the McDonald brothers, but the fast food chain McDonald, how the franchise got rapidly spread across the globe and the person behind it. With the film having both good and bad side, it stayed mostly neutral. But due to the main character, you would see too much lean on what seems the reason behind the McDonald's today's popularity. So it's like another typical American founders' story like Apple,Facebook.I mean not the one who found the company with all the hard works,but the one who dived in and took all the credit.Ray Kroc was a traveling salesman and he's not doing any good. But one day he meets the brothers who had started a modernised kitchen and its fast food service. He shows lots of interest in it and so he joins hands with them. With his new ideas, how he makes a fortune out of it and the future of the company, all revealed in the later part.An enjoyable film.Particularly for Michael Keaton. Well directed film as well.Film wise it was a good one, but the story wise not morally right.It was about the flaws in our society, our system.Some men can do anything like pulling others leg to climb the success ladder.It's not them to blame completely, because they had struggled enough to understand their future path. So definitely for some people, this film would inspire. If you are a regular McDonalds' customer, you should watch it. Otherwise, just to learn the truth, it is worth a watch.",
                Rating = 7
            };

            svc.AddReview(r3);

            var r4 = new Review()
            {
                MovieId = m4.Id,
                Name = "John Chard",
                CreatedOn = new DateTime(2014, 09, 23),
                Comment = "Life's a bitch and she's back on heat! They Live is directed by John Carpenter who also adapts the screenplay form the short story Eight O'Clock in the Morning written by Ray Nelson. It stars Roddy Piper, Keith David and Meg Foster. Music is by Alan Howarth (and Carpenter) and cinematography by Gary B. Kibbe. Unemployed drifter Nada (Piper) wanders into the city looking to find work, but upon finding a unique pair of sunglasses he sees a different world to everyone else. It's a world frequented by an alien race who are using the Earth for their own nefarious means. See The Truth! Carpenter does subversive sci-fi and it's a whole bunch of fun. Stripped back it's evident that They Live is Carpenter's wry observation on the politico posers who endorse the rich getting richer and everybody else sliding down the pole; to where they stop nobody knows! It's also a blatant paean to the glorious years of the 1950s when paranoia based sci-fi schlockers and creaky creature features ruled the air waves. It's also a wonderfully macho driven action movie, laced with comedy as well. You can rest assured there will be plenty of shooting, punching, dodging and spoken lines to make you smile. Piper is no Kurt Russell, but we shouldn't hold that against him because he fills the role nicely. With muscular frame, 80s hair and a quip on the tongue, he is most assuredly a Carpenter leading man for the 80s. Alongside him is the reassuring presence of Keith David, himself a beefcake and also one of the coolest muthas on the planet. It's easy to believe that these two can save the planet, even after nearly beating each other to a pulp during a prolonged side-alley fight sequence, where Carpenter doesn't miss a chance to parody professional wrestling. While away from the beef, Meg Foster gets the lead lady role, with those amazing eyes nestling in perfectly with the world Carpenter has created. Carpenter does political? Yes, but it's not the be all and end all of his intentions. He wanted to make an action sci-fi schlocker with sly politico undertones as motives. And that's exactly what he did. Joyously so. 8/10",
                Rating = 8
            };

            svc.AddReview(r4);

            var r5 = new Review()
            {
                MovieId = m5.Id,
                Name = "Dean09199",
                CreatedOn = new DateTime(2019, 10, 12),
                Comment = "It was okay. Actually worse than okay. Very slow paced & long movie and nothing much happened. We also had flashbacks back and forth. In general, It was boring to be honest. I think people are giving it such a big rating because of Breaking Bad name and universe. In reality this movie had zero tense and zero intrigue comparing to Breaking Bad TV show.",
                Rating = 4
            };

            svc.AddReview(r5);

            var r6 = new Review()
            {
                MovieId = m6.Id,
                Name = "Eclectic-Boogaloo",
                CreatedOn = new DateTime(2019, 07, 04),
                Comment = "I expected it to be as dated and as much of a product of its time as it looked to be but-- nope. 50 years after its release Easy Rider is still as relevant as ever. It's a powerful and uncompromising depiction of America's culture war that doesn't portend to have any good guys, much less answers, as it follows three guys (played by stars Fonda, Hopper, and Nicholson) who are biking cross country and engaged in the use and spread of drugs. But still, the divide is real. Just as real today as it is today. Free love, Individual liberty and maybe a little bit of decadence on one side-- bigotry, closed mindedness, and hatred on the other. I won't spoil what happens as it really should be seen. A really powerful film.",
                Rating = 8
            };

            svc.AddReview(r6);

            var r7 = new Review()
            {
                MovieId = m7.Id,
                Name = "Gimly",
                CreatedOn = new DateTime(2017, 06, 11),
                Comment = "Absolutely ridiculous, but it appeals to the youthful rocker within me. Also Adam Sandler is place mercifully far into the background.",
                Rating = 5
            };

            svc.AddReview(r7);

            var r8 = new Review()
            {
                MovieId = m8.Id,
                Name = "tmdb44006625",
                CreatedOn = new DateTime(2019, 03, 09),
                Comment = "Thomas Jane and John Travolta are good in this, but man is The Punisher one stupid movie. I'm willing to suspend my disbelief quite a bit but how is it a gangster assassin doesn't double tap and headshot their target when they have them at point blank? This mafia family soon proves to be one of the dumbest in all of gangster cinema, leaving their loved ones completely open to be followed by Frank Castle, falling for a really terrible manipulation scheme, and how did they find out where Frank Castle's apartment was? This is the kind of try-hard movie that Hollywood makes every so often when they have a revenge story script, an alpha-male protagonist, and all the rights to heavy metal tracks. It tries so hard to be cool and fails so spectacularly it's actually painful to watch.",
                Rating = 3
            };

            svc.AddReview(r8);

            var r9 = new Review()
            {
                MovieId = m9.Id,
                Name = "John Chard",
                CreatedOn = new DateTime(2019, 03, 18),
                Comment = "First Blood is directed by Ted Kotcheff and adapted by Michael Kozoll, William Sackheim and Sylvester Stallone, from the novel written by David Morrell. It stars Stallone, Brian Dennehy, Richard Crenna, Bill McKinney and Jack Starrett. Cinematography is by Andrew Laszlo and the music scored by Jerry Goldsmith. Locations for the shoot were in British Columbia. John Rambo (Stallone), ex Vietnam war veteran, wanders into small town Oregon and is met with hostility by Sheriff Will Teasle (Dennehy). Arrested for a trumped up charge of vagrancy, Rambo is subjected to rough house treatment by Teasle and his staff. Fuelled by the haunted images of his time in Vietnam, Rambo breaks out of custody and makes for the hills, with Teasle and the force in hot pursuit. But this is terrain made for Rambo, an expert soldier trained to survive and kill, it's a war, Rambo versus the rest. The character of John Rambo would slip into pop culture and forever be associated with cartoon excess. By his own admission, Stallone himself felt they dropped the ball after the original film, and he's right. However, First Blood is often wrongly lumped in as part of that excessive package, because it's a film well worthy of revisits to see just how well it holds up as a taut and tense thriller. A film led by the bold theme of showing just how badly some of America's soldiers were received upon returning from Vietnam. First Blood delves deeper into the psyche of one such soldier whilst casting a caustic eye over small town Americana. The makers rarely let up on the troubling thematics at work, developing Rambo with clinical strokes as the plot unfolds, the trick in the tail being that the audience are firmly on his side as he goes about bringing his Vietnam to the picturesque place the locals call home. By 1982, it seems, America was on the side of the soldier. Stallone is a perfect fit for the role, his physicality unquestionable, he brings the brood and pain to Rambo like few actors of his ilk ever could. The sarcastic may point to his lack of dialogue hardly constituting a great acting performance, that's rot, because this is a fine character portrayal by Stallone. Dennehy is on fine form as the brutish bully Sheriff who just couldn't leave Rambo alone, while in the support ranks McKinney and Starrett leave good impressions. The interesting casting comes with Crenna as Rambo's \"maker\", Col. Samuel Trautman. The role was Kirk Douglas' hook line and sinker, but he wanted a different script and insisted that the film end the same way as the novel. In the end the makers just couldn't give in to his requests and he walked at the last minute. In stepped Crenna to put a bit of father figure pathos into Trautman, and subsequently earning himself a three picture deal and a place in pop culture in the process. It's also a film that's photographed with great skill by Lazlo. He captures the British Columbia mountains and forests with beautiful scope, but in keeping with the tone of the film his colour palette is suitably grey and green. Goldsmith provides an effective score, particularly when the narrative is focusing on Rambo's alienation, while the stunt work is very impressive. Even if we drift away from the theme of the piece, it still works extremely well as an action movie drama, be it motorcycle/helicopter pursuits, or jungle warfare, First Blood pumps the blood frequently. All neatly constructed by the director of Weekend at Bernie's! On release it grabbed the attention and became a monster box office hit Worldwide, today it still stands as a damn great movie, and you know what? Stallone and co were right and Kirk Douglas was wrong. 9/10",
                Rating = 9
            };

            svc.AddReview(r9);

            var r10 = new Review()
            {
                MovieId = m10.Id,
                Name = "tshodan",
                CreatedOn = new DateTime(2000, 08, 24),
                Comment = "This movie starts slow and begins moving quickly as we see an outstanding modern version of faust (more like the Devil went down to Georgia). The end is a spectacular show down between Ralph Machio on a classic guitar vs. A rock & roll demon.",
                Rating = 8
            };

            svc.AddReview(r10);

            var r11 = new Review()
            {
                MovieId = m11.Id,
                Name = "Ian Beale",
                CreatedOn = new DateTime(2017, 02, 14),
                Comment = "This film is about a soldiers quest to find a renegade and insane Colonel (a bald Brando in an extended cameo) who has hidden himself away in the depths of the jungle and is causing all manner of commotion. Quite what it was - I can't remember, but it was important enough to go down stream in search of him. Sheen's character decides to head down river with his fellow soldiers and seek out the bald lunatic before its too late. Robert Duvall is hilarious as a war immune soldier - especially when a shell explodes near him and he merely gives it a disinterested glance. Amusing! On the whole, though, this is a ponderous trip - the film seems to meander aimlessly with little to keep this viewer interested.",
                Rating = 5
            };

            svc.AddReview(r11);

            var r12 = new Review()
            {
                MovieId = m12.Id,
                Name = "JPV852",
                CreatedOn = new DateTime(2019, 12, 10),
                Comment = "Well, the last 15-minutes were great, the first 2.5 hours on the other hand was... uneventful. I have an interest in Hollywood, more from the 1980s though, so some of the slower scenes still kept my attention, but there's no real plot and minimal character development. That said, DiCaprio and Pitt both give great performances and Margot Robbie of course had her moments, however I could only chuckle during the theater scene when she kicked her bare feet up. Okay, Quentin, lol",
                Rating = 6
            };

            svc.AddReview(r12);

            var r13 = new Review()
            {
                MovieId = m13.Id,
                Name = "Gimly",
                CreatedOn = new DateTime(2018, 01, 12),
                Comment = "How do you review a movie like The Warriors? I've got a real short way for ya: The Warriors is the best movie of the 1970s.",
                Rating = 9
            };

            svc.AddReview(r13);

            var r14 = new Review()
            {
                MovieId = m14.Id,
                Name = "cleaf",
                CreatedOn = new DateTime(2004, 03, 28),
                Comment = "The Big Lebowski is the type of movie that is so funny, and so clever, you want nothing more but to meet the Coen brothers, congratulate them personally for their unique talent, and get inside their heads and find out what makes these two geniuses \"tick\". The main characters are Jeff Bridges (who plays such broad roles like The Muse, The Contender, and Sea Biscuit), John Goodman (who should have won an oscar for best supporting actor for his character, Walter Sobchak)Juliane Moore (Maude Lebowski)and Steve Buscemi (who is unique in every Coen Brother movie). The first time I saw this movie, I will admit that I enjoyed it, but did not fully appreciate its level of humor and raw talent. I thought the middle section was a bit too depressing and long. But trust me, this is a movie that gets more funny every time you see it, even if it's your thousandth time seeing it. Its level of comedy, action, brutality, and vulgarity become that much more evident and important. The characters are brilliantly written by the coen brothers, and, likewise, are brilliantly portrayed by the actors. The Big Lebowski is like no other film. It will make you laugh and it will make you cry. There is no other film such as TBL that is sharp and witty all the way through. One of the Joel and Ethan Coen's best, and one of the movie industry's best comedic film of all time. You want to go see this flick.",
                Rating = 10
            };

            svc.AddReview(r14);

            var r15 = new Review()
            {
                MovieId = m15.Id,
                Name = "Mark B",
                CreatedOn = new DateTime(2020, 10, 28),
                Comment = "Se7en put David Fincher on the map with this uber-creepy mystery thriller. The crime scenes are so grisly Seven is often ranked with top horror movies. And the ending -- hoo boy. One of the best twists in modern movie history.",
                Rating = 10
            };

            svc.AddReview(r15);

            var r16 = new Review()
            {
                MovieId = m16.Id,
                Name = "Thatman95",
                CreatedOn = new DateTime(2001, 05, 17),
                Comment = "While the Batman franchise has been much maligned in recent years due to the disappointing performance of the last live-action film, Forever was second in quality only to the first Bat-film. It added color back into a Gotham that had gotten way too claustrophobic, and brought the tone back to something resembling the comics. Jim Carrey is a scene-stealer and dead on as The Riddler, and Val Kilmer is the perfect Bruce Wayne and Batman. Tommy Lee Jones does a great turn as Two-Face, unfortunately he isn't given enough to do and therefore comes across too cartoony, minus the angst of the character in the comics. One other big complaint is the new score - gone are Danny Elfman's orchestrations. Elliot Goldenthal's music would have been fine if not for his predecessor. Most people tend to lump this one in the 'lousy' section, it seems, but it was one of the biggest movies of '95 and a very faithful adaption overall. Now if they'd only release the director's cut",
                Rating = 10
            };

            svc.AddReview(r16);

            var r17 = new Review()
            {
                MovieId = m17.Id,
                Name = "Justin Lopez",
                CreatedOn = new DateTime(2019, 11, 06),
                Comment = "Stan Lee would be proud! Great story, great message, and great animation.",
                Rating = 9
            };

            svc.AddReview(r17);

            var r18 = new Review()
            {
                MovieId = m18.Id,
                Name = "gerrymcd",
                CreatedOn = new DateTime(2007, 03, 06),
                Comment = "I watched this film because i had heard so much about it and it lived up to they hype. The film is totally gripping and Forrest Wittaker is superb as the dictator. I didn't stop watching the film for one second throughout you simply couldn't. Both Whittaker's and the Scottish doctor are very charming characters particularly Whittaker's in the beginning. Its rare to see such a fantastic film as this which moves at a nice pace pealing away the layer of the dictators true persona and having such a great cast and great acting as well.",
                Rating = 8
            };

            svc.AddReview(r18);

            var r19 = new Review()
            {
                MovieId = m19.Id,
                Name = "Winter23",
                CreatedOn = new DateTime(2020, 07, 18),
                Comment = "I liked it so much I bought the DVD! It silly, it's dangerous. I like that Kevin uses the same actors he's used in his previous programs. Love, Kevin James! Big smile!!",
                Rating = 8
            };

            svc.AddReview(r19);

            var r20 = new Review()
            {
                MovieId = m20.Id,
                Name = "fran-717-228142",
                CreatedOn = new DateTime(2018, 11, 04),
                Comment = "This is such a nostalgic warmovie for me. In the middle or the 80's I saw it at the first time. It came so right when they talked about Russia and America every evening in the News and how they could end the world. Of course it's a film without realistic feeling but you buy it anyway. There are so many actors in the beginning of their careers and the make their roles just perfect. One of it's kind also in this era of film though the russian and cuban forces actually speak their own languages and that makes the film so much better. See it and remember the cold war and how fragile we are during such conditions.",
                Rating = 10
            };

            svc.AddReview(r20);













































        }
    }
}
