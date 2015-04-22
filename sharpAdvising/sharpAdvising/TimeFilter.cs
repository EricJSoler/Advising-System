using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Xml.Serialization;//added 2/25
using System.IO;

namespace sharpAdvising
{
    public class TimeFilter
    {

        public TimeFilter()//The default construct will simple create a schedule with one class in it
        {
            preReqsQualifiedfFor = LoadPreReqsFromFile("ClassOrder.xml"); //Hey i want this to be read only how does AsReadOnly Look?
            List<Course> PotentialSchedule = new List<Course>();
            PotentialSchedule.Add(new Course(preReqsQualifiedfFor[0].courses[0]));

        }

        public TimeFilter(int numberOfClasses)//This will establish a schedule based on the number of classes you wish to take Assuming the student is starting in "quarter 0"
        {
            preReqsQualifiedfFor = LoadPreReqsFromFile("ClassOrder.xml");
            List<Course> PotentialSchedule = new List<Course>();

            int availableCourseCounter = 0;
            foreach (string element in preReqsQualifiedfFor[0].courses)
            {
                availableCourseCounter++;
            }

            if (availableCourseCounter < numberOfClasses)
            {
                numberOfClasses = availableCourseCounter;
            }



            for (int i = 0; i < numberOfClasses; i++)
            {

                //PotentialSchedule.Add(new Course(preReqsQualifiedfFor[0].courses[i])); THIS IS THE REAL CODE BUT FOR NOW I DONT WANNA SPLIT UP THE COURSE IDS INTO WHAT THEY NEED TO BE FOR THE DATA BASE
                string numID;
                string dID;
                Console.WriteLine("input d id");
                dID = Console.ReadLine();
                Console.WriteLine("input a num id");
                numID = Console.ReadLine();
                PotentialSchedule.Add(new Course(numID, dID));
                Console.WriteLine("you done homie");
            }
            matches = new List<Zaps>();

            foreach (Course element in PotentialSchedule)
            {
                addMatches(element,0);
                //PotentialSchedule.RemoveAt(0);     
            }

        }

        public TimeFilter(int numberOfClassesRequested, List<string> classesAlreadyCompleted)//This will establish a schedule for a student that has already recieved some college creditis
        {
            preReqsQualifiedfFor = LoadPreReqsFromFile("ClassOrder.xml");
            potentialSchedule = new List<Course>();

            int j = 0;
            do
            {
                for (int i = 0; i < preReqsQualifiedfFor[j].courses.Count; i++)
                {
                    if (courseNotCompleted(preReqsQualifiedfFor[j].courses[i], classesAlreadyCompleted))
                    {
                        potentialSchedule.Add(new Course(preReqsQualifiedfFor[j].courses[i]));
                    }

                }
                j++;
            } while (potentialSchedule.Count < numberOfClassesRequested);

        }

        public List<Quarter> LoadPreReqsFromFile(string fileName)//Load the "XML1" a list of pre requisites from preReq Module
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(List<Quarter>));
                return (List<Quarter>)XML.Deserialize(stream);
            }
        }
        public int coursesInQuarterNode(int quarterNode)
        {
            return preReqsQualifiedfFor[quarterNode].courses.Count;
        }
        public int whichQuarter()
        {
            int x = 0;
            return x++;
        }


        private bool courseNotCompleted(string courseToBeTested, List<string> coursesTestedAgainst)//pass in the coursethat is to be tested and the List of courses completed Right now the 2nd parameter is a list of string but itl probably be an xml file name lata
        {
            int count = 0;
            foreach (string element in coursesTestedAgainst)
            {
                if (courseToBeTested == element)
                {
                    count++;
                    return false;
                }
            }
            return true;
        }
        public List<Quarter> preReqsQualifiedfFor;
        public List<Course> potentialSchedule;
        public List<Zaps> matches; //This will consist of a List of course objects that will contain what sections are already filled to allow for testing.

        public void addMatches(Course recievedCourse, int termNum)
        {
            int count = (matches.Count());
            matches.Add(new Zaps());
            matches[count].courseName = recievedCourse.courseID;
            if (count == 0)
            {
                foreach (Section ele in recievedCourse.ownedTerms[termNum].ownedSections)
                    matches[0].sectionOptions.Add(new Section(ele.sectionID));
                return;//I know im not supossed to return from a void function but Im pretty sure I read that this will just end the function
            }

            bool matchHasPriority = false;
            bool courseHasPriority = false;

            int matchCounter = 0;
            for (int i = 0; i < (matches.Count() - 1); i++ )
            {
                for (int j = 0; j < (matches[i].sectionOptions.Count()); j++ )
                {
                    for (int k = 0; k < (recievedCourse.ownedTerms[termNum].ownedSections.Count());k++ )//replace this 0 with an integer that depends on the qquarter you are filling
                    {

                        int sizeOfSectionForMatch = matches[i].sectionOptions.Count();
                        int sizeOfComparedCourse = recievedCourse.ownedTerms[termNum].ownedSections.Count();//Replace this 0 with the quarter you are looking for
                        if (sizeOfSectionForMatch == 1)
                            matchHasPriority = true;
                        if (sizeOfComparedCourse == 1)
                            courseHasPriority = true;
                        if (recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID == matches[i].sectionOptions[j].sectionID && courseHasPriority && matchHasPriority)//FIX THIS
                        {
                            Console.WriteLine("THese classes overlap");

                            //I NEED A FUNCTION TYPE THING HERE THAT RANKS THE IMPORTANCE OF THE CLASSES FOR NOW IM JUST GONNA REMOVE THE CURRENT COURSE
                            matches.RemoveAt(count);
                            return;
                        }
                        else if (matchHasPriority && recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID == matches[i].sectionOptions[j].sectionID)
                        {
                            //DO NOTHING I need thin here so that last else doesnt get executed
                        }
                        else if (recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID == matches[i].sectionOptions[j].sectionID && !matchHasPriority)
                        {
                            matches[matchCounter].sectionOptions.RemoveAt(j);
                            matches[count].sectionOptions.Add(new Section(recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID));
                        }
                        else if (recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID == matches[i].sectionOptions[j].sectionID)
                        {
                            matches[i].sectionOptions.RemoveAt(j);
                        }
                        else
                            matches[count].sectionOptions.Add(new Section(recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID));
                    }
                }
            }
        }

        public bool hasCourseAlreadyBeenRecomended(Course cour)
        {
            foreach (Zaps element in matches)
            {
                if (cour.courseID == element.courseName)
                {
                    return true;
                }

            }
            return false;
        }

    }




}
