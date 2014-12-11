using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace house
{
    class Program
    {
        double m_totalAmount = 430000;
        double m_repay = 0;
        double m_pay = 0;
        double m_interest = 0;
        double m_totleinterest = 0;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.m_totalAmount = 430000;
            program.m_repay = 0;
            //double test = Financial.Pmt(rate, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
            
            double[] rateArray = { 0.0531 / 12, 0.05508 / 12, 0.05814 / 12, 0.066555 / 12, 0.0594 * 0.7 / 12, 0.0594 * 0.7 / 12, 0.064 * 0.7 / 12, 0.0705 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12, 0.0655 * 0.7 / 12 };
            for (int i = 0; i < rateArray.Length; i++)
            {
                program.outputResult(rateArray[i], i + 1, (20 - i) * 12, program.m_totalAmount - program.m_repay);
            }
            Debug.WriteLine("success");
        }

        public void outputResult(double rate, int year, int totalCount, double totalAmount)
        {
            Debug.WriteLine("{0} --- The return amount is : " + Financial.Pmt(rate, totalCount, totalAmount, 0, DueDate.EndOfPeriod).ToString(), year + 2004);
            Debug.Write("interest   ");
            Debug.Write("Corpus     ");
            Debug.Write("repay      ");
            Debug.Write("residual   ");
            Debug.Write("should Pay   ");
            Debug.Write("Total Pay   ");
            Debug.Write("Year interest   ");
            Debug.Write("total interest   ");
            Debug.WriteLine("");
            for (int i = 1; i < 13; i++)
            {
                //double interest = -Financial.IPmt(rate, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);		        
                //Debug.Write(interest.ToString("0.00"));
                //double corpus = -Financial.PPmt(rate, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                //Debug.Write("    " + corpus.ToString("0.00"));
                //m_repay = m_repay + corpus;
                //Debug.Write("    " + m_repay.ToString("0.00"));
                //double residual = m_totalAmount - m_repay;
                //Debug.Write("    " + residual.ToString("0.00"));
                //Debug.WriteLine();
                if (year - 1 == 4 && i == 1)
                {
                    //interest = interest * 0.85 / 0.7;
                    //Debug.WriteLine("The return amount of this month is {0}", interest + corpus);
                    double interest = -Financial.IPmt(0.0594 * 0.85 / 12, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                    m_totleinterest += interest;
                    Debug.Write(interest.ToString("0.00"));
                    double corpus = -Financial.PPmt(0.0594 * 0.85 / 12, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                    Debug.Write("    " + corpus.ToString("0.00"));
                    m_repay = m_repay + corpus;
                    Debug.Write("    " + m_repay.ToString("0.00"));
                    double residual = m_totalAmount - m_repay;
                    Debug.Write("    " + residual.ToString("0.00"));
                    Debug.Write("    " + (interest + corpus).ToString("0.00"));
                    m_pay = m_pay + interest + corpus;
                    Debug.Write("    " + (m_pay).ToString("0.00"));                   
                    Debug.Write("    " + (m_totleinterest).ToString("0.00"));
                    Debug.WriteLine("");
                }
                else if (year - 1 == 8 && i == 11)
                {
                    totalAmount = totalAmount - 20000;
                    m_repay = m_repay + 20000;
                    double interest = -Financial.IPmt(rate, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                    m_totleinterest += interest;
                    Debug.Write(interest.ToString("0.00"));
                    double corpus = -Financial.PPmt(rate, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                    Debug.Write("    " + corpus.ToString("0.00"));
                    m_repay = m_repay + corpus;
                    Debug.Write("    " + m_repay.ToString("0.00"));
                    double residual = m_totalAmount - m_repay;
                    Debug.Write("    " + residual.ToString("0.00"));
                    Debug.Write("    " + (interest + corpus).ToString("0.00"));
                    m_pay = m_pay + interest + corpus;
                    Debug.Write("    " + (m_pay).ToString("0.00"));
                    m_interest = (675864.21 - m_pay - residual) * 100 / 12 / residual;
                    Debug.Write("    " + (m_interest).ToString("0.00"));
                    Debug.Write("    " + (m_totleinterest).ToString("0.00"));
                    Debug.WriteLine("");
                }
                else
                {
                    double interest = -Financial.IPmt(rate, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                    m_totleinterest += interest;
                    Debug.Write(interest.ToString("0.00"));
                    double corpus = -Financial.PPmt(rate, i, totalCount, totalAmount, 0, DueDate.EndOfPeriod);
                    Debug.Write("    " + corpus.ToString("0.00"));
                    m_repay = m_repay + corpus;
                    Debug.Write("    " + m_repay.ToString("0.00"));
                    double residual = m_totalAmount - m_repay;
                    Debug.Write("    " + residual.ToString("0.00"));
                    Debug.Write("    " + (interest + corpus).ToString("0.00"));
                    m_pay = m_pay + interest + corpus;
                    Debug.Write("    " + (m_pay).ToString("0.00"));
                    m_interest = (675864.21 - m_pay - residual) * 100 / 12 / residual;
                    Debug.Write("    " + (m_interest).ToString("0.00"));                    
                    Debug.Write("    " + (m_totleinterest).ToString("0.00"));
                    Debug.WriteLine("");
                }
            }
        }
    }
}