namespace Utils
{
    public class FracToWhole
    {
        public static void Convert1(List<double> a)
        {
            
            bool b,p;
            b = false; p = true;

            foreach(var t in a)
            {
                if(!IsWholeNumber(t))
                {
                    b = true;
                    
                    break;
                }
            }

            if (b)
            {
                int c = 0;
                while (c < a.Count)
                {
                    a[c] = Math.Round(2 * a[c],0);
                    c++;

                }
                c = 0;

                while (c<a.Count)
                {
                    if (!(a[c] % 2 == 0))
                    {
                        p = false;
                        break;
                    }
                    c++;
                }

                if (p)
                {
                    c = 0;
                    while (c < a.Count)
                    {
                        a[c++] /= 2;
                    }
                }

            }
            
            
           
        } 

        static bool IsWholeNumber(double value)
            {
                return Math.Abs(value % 1) < double.Epsilon;
            }
    }
    }
