using System.Collections.Generic;

namespace MultiOsAppAndroid
{
    public static class ResourceHelper
    {
        static Dictionary<string, int> resourceDictionary = new Dictionary<string, int>();
        public static int TranslateDrawable(string drawableName)
        {
            switch (drawableName)
            {
                case "back_0":
                    return Resource.Drawable.back_0;
                case "back_1":
                    return Resource.Drawable.back_1;
                case "back_2":
                    return Resource.Drawable.back_2;
                case "back_3":
                    return Resource.Drawable.back_3;
                default:
                    return -1;
            }
        }
        public static int TranslateDrawableWithReflection(string drawableName)
        {
            if (resourceDictionary.ContainsKey(drawableName))
            {
                return resourceDictionary[drawableName];
            }

            var resourceVal = TranslateDrawable(drawableName);
            resourceDictionary.Add(drawableName, resourceVal);

            return resourceVal;
        }
    }
}