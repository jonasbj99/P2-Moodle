using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Calender : MonoBehaviour
{
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        //Constructor of day
        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.dayColor = dayColor;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum); 
        }

        //Call this when updating the color so that both the dayColor is updated, as well as the visual color on the screen
        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor; 
            dayColor = newColor;
        }

        //When updating the day we decide wether we should show the dayNum based on the color of the day
        //This means the color should always be updated before the day is updated
        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == Color.green)
            {
                obj.GetComponentInChildren<TMP_Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<TMP_Text>().text = "";
            }
        }
    }

    //All the days in the month. After we make our first calender we store these days in this list so we do not
    //have to recreate them every time
    private List<Day> days = new List<Day>();

    //Setup in editor since there will always be six weeks
    public Transform[] weeks;

    //This is the text object that displays the current month and year
    public TMP_Text MonthAndYear;

    //This currDate is the date our calender is currently on. The year and the month is based on the calender, while the day itself is
    // almost always 1.
    //If you have some option to select a day in the calender, you would want the change this objects day value to the last day
    public DateTime currDate = DateTime.Now;

    //This is the highlight color of the current day in the calender. This is public so it can easily be changed from unity inspector window.
    //Note the standard alpha value is zero and needs to be turned up.
    public Color highlight;

    //In start we set the calender to the current date
    private void Start()
    {
        UpdateCalender(DateTime.Now.Year, DateTime.Now.Month);
    }

    //Anytime the calender is changed we call this to make sure we have the right days for the right month/year
    void UpdateCalender(int year, int month)
    {

        DateTime temp = new DateTime(year, month, 1);
        currDate = temp;
        MonthAndYear.text = temp.ToString("MMM") + " " + temp.Year.ToString();
        int startDay = GetMonthStartDay(year, month);
        int endDay = GetTotalNumberOfDays(year, month);

        //Creating the days
        //This only happens for our first update calender when we have no day objects therefore we must create them
        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.gray, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }
        //loop through days
        //since we already have the days objects, we can just update them rather than creating new ones
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if(i < startDay || i-startDay >= endDay)
                {
                    days[i].UpdateColor(Color.gray);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                days[i].UpdateDay(i - startDay);
            }
        }

        //This just checks if today is on our calender. If so, we highlight it in the public highlighted variable accessed from unity
        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(highlight);
        }

    }

    //This returns which day of the week the month is starting on
    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);

        //Day of week Sunday==0, Saturday==6 etc.
        return (int)temp.DayOfWeek;
    }

    //Gets the number of days in the given month
    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    //This either adds or subtracts one month from your currDate
    //The arrow keys will use this function to switch to past or future month

    public void SwitchMonth(int direction)
    {
        if(direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalender(currDate.Year, currDate.Month);
    }
}

//lavet vha. hjælp fra youtube tutorial https://www.youtube.com/watch?v=cMwCZhZnE4k
