using System;
using System.Collections.Generic;

class ScriptureLibrary
{
    private List<Scripture> scriptures;

    
    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John 3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Genesis 1:1"), "In the beginning God created the heavens and the earth."),
            new Scripture(new Reference("Proverbs 3:5"), "Trust in the LORD with all your heart and lean not on your own understanding."),
            new Scripture(new Reference("Psalm 23:1"), "The LORD is my shepherd, I lack nothing."),
            new Scripture(new Reference("Matthew 28:19"), "Therefore go and make disciples of all nations, baptizing them in the name of the Father and of the Son and of the Holy Spirit."),
            new Scripture(new Reference("Romans 12:2"), "Do not conform to the pattern of this world, but be transformed by the renewing of your mind. Then you will be able to test and approve what God’s will is—his good, pleasing and perfect will."),
            new Scripture(new Reference("Philippians 4:13"), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("John 14:6"), "Jesus answered, 'I am the way and the truth and the life. No one comes to the Father except through me.'"),
            new Scripture(new Reference("Jeremiah 29:11"), "For I know the plans I have for you,” declares the LORD, “plans to prosper you and not to harm you, plans to give you hope and a future."),
            new Scripture(new Reference("Psalm 46:1"), "God is our refuge and strength, an ever-present help in trouble."),
            new Scripture(new Reference("Isaiah 40:31"), "But those who hope in the LORD will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint.")
        };
    }

    internal Scripture GetRandomScripture()
    {
        throw new NotImplementedException();
    }
}
