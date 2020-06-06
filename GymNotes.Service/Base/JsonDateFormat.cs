using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.Base
{
  public class JsonFormatDate : IsoDateTimeConverter
  {
    public JsonFormatDate(string format)
    {
      DateTimeFormat = format;
    }
  }
}