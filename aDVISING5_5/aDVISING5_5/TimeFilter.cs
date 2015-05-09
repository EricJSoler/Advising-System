using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Xml.Serialization;//added 2/25
using System.IO;

namespace sharpAdvising
{
    /// <summary>
    /// TODO: Update the time filter to deal with students not starting in quarter 0, If time allows should also be updated to include options to take x number of courses
    /// </summary>

   
    public class TimeFilter
    {

        public TimeFilter()
        {

        }
       
        public TimeFilter(int numberOfClasses)///This will establish a schedule based on the number of classes you wish to take Assuming the student is starting in "quarter 0"
        {
            List<Course> PotentialSchedule = new List<Course>();///TODO: this potentialSchedule should come from the Pre-Req filter maybeRename it as coursesQualified for


            for (int i = 0; i < numberOfClasses; i++)///TODO: this loop should be performed on the coursesQualifed for the comes from the PreReq Filter
            {
                string numID;
                string dID;
                Console.WriteLine("input d id");
                dID = Console.ReadLine();
                Console.WriteLine("input a num id");
                numID = Console.ReadLine();
                PotentialSchedule.Add((new Course(numID, dID)));
                Console.WriteLine("you done homie");
            }
            matches = new List<Match>();

            foreach (Course element in PotentialSchedule)
            {
                addMatches(element,0);
                //If we were allowed to schedule the course remove it     
            }
            Console.WriteLine("here is where I stopped");
        }


        


        public int whichQuarter()
        {
            int x = 0;
            return (x++);
        }


        private bool courseNotCompleted(string courseToBeTested, List<string> coursesTestedAgainst)///pass in the coursethat is to be tested and the List of courses completed Right now the 2nd parameter is a list of string but itl probably be an xml file name lata
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
        public List<Match> matches; ///This will consist of a List of course objects that will contain what sections are already filled to allow for testing.

        public void addMatches(Course recievedCourse, int termNum)
        {
            int count = (matches.Count());
            matches.Add(new Match());
            matches[count].departmentID = recievedCourse.departmentID;
            matches[count].numberID = recievedCourse.numberID;
            if (count == 0)
            {
                foreach (Section ele in recievedCourse.ownedTerms[termNum].ownedSections)
                    matches[0].sectionOptions.Add(new Section(ele.sectionID));
                return;
            }

            bool matchHasPriority = false;
            bool courseHasPriority = false;

            int matchCounter = 0;
            for (int i = 0; i < (matches.Count() - 1); i++ )
            {
                for (int j = 0; j < (matches[i].sectionOptions.Count()); j++ )
                {
                    for (int k = 0; k < (recievedCourse.ownedTerms[termNum].ownedSections.Count());k++ )//replace this 0 with an integer that depends on the quarter you are filling
                    {

                        int sizeOfSectionForMatch = matches[i].sectionOptions.Count();
                        int sizeOfComparedCourse = recievedCourse.ownedTerms[termNum].ownedSections.Count();//Replace this 0 with the quarter you are looking for
                        if (sizeOfSectionForMatch == 1)
                            matchHasPriority = true;
                        if (sizeOfComparedCourse == 1)
                            courseHasPriority = true;
                        if (recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID == matches[i].sectionOptions[j].sectionID && courseHasPriority && matchHasPriority)//FIX THIS
                        {
                            Console.WriteLine("These classes overlap");

                            ///TODO: NEED A FUNCTION TYPE THING HERE THAT RANKS THE IMPORTANCE OF THE CLASSES FOR NOW IM JUST GONNA REMOVE THE CURRENT COURSE
                            matches.RemoveAt(count);
                            return;
                        }
                        else if (matchHasPriority && recievedCourse.ownedTerms[termNum].ownedSections[k].sectionID == matches[i].sectionOptions[j].sectionID)
                        {
                            //DO NOTHING This is here to avoid that last else from being executed theres probably a better way to do this but serves its purpose
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

        public bool hasCourseAlreadyBeenRecomended(Course course)
        {
            foreach (Match element in matches)
            {
                if (course.departmentID == element.departmentID && course.numberID == element.numberID)
                {
                    return true;
                }

            }
            return false;
        }

    }




}
