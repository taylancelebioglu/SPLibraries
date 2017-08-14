using System;
using System.ComponentModel;
using System.Globalization;

namespace SharePoint.Libraries.Entity
{
    public class ValueTypeConverter
    {
        public T ConvertValue<T>(object val, CultureInfo cultureInfo)
        {
            Type t = typeof(T);

            try
            {
                Type u = Nullable.GetUnderlyingType(t);
                Type finalType = t;

                //check if type is nonNullable 
                if (u == null && t != typeof(string))
                {
                    //type is nonNullable and value is null
                    if (val == null)
                    {
                        throw new ArgumentNullException(t.ToString(), string.Format("{0} data type can not be set!", t.ToString())
                       );
                    }
                }
                else
                {
                    //type is nullable and value is null
                    if (val == null)
                    {
                        return default(T);//returns null
                    }
                    if (t != typeof(string))
                    {
                        //set final type
                        finalType = u;
                    }
                }


                //convert enum type
                if (finalType.BaseType == typeof(Enum))
                    return (T)Enum.Parse(finalType, val.ToString());


                //convert guid value
                if (t.Equals(typeof(Guid)) || t.Equals(typeof(Guid?)))
                    return (T)Convert.ChangeType(new Guid(val.ToString()), finalType);

                //convert complex types
                if (IsComplexType(val))
                    return (T)val;

                //convert primitive types
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    //convert culture independent value
                    if (t is IConvertible)
                        return (T)Convert.ChangeType(val, finalType);

                    //convert culture dependent value
                    return (T)Convert.ChangeType(val, finalType, cultureInfo);

                }

                throw new Exception("Type conversation error has occured");

            }
            //throw null exception
            catch (ArgumentNullException)
            {
                throw;
            }
            //throw argument exception
            catch (Exception)
            {
                string valText = val == null ? "null" : val.ToString();
                throw new ArgumentException
                    (string.Format("Error when value '{0}' is converting to {1} data type", valText, t.ToString()));
            }
        }

        public bool IsComplexType(object obj)
        {
            return obj.GetType() != typeof(object) && Type.GetTypeCode(obj.GetType()) == TypeCode.Object;
        }

    }
}