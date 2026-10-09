using System;

public class Level
{
    private string _firstName;
    private string _lastName;
    private char _gender; // 'M' or 'F'
    private bool _isRegistered;

    public Level()
    {
        _firstName = "";
        _lastName = "";
        _gender = ' ';
        _isRegistered = false;
    }

    public Level(string firstName, string lastName, char gender, bool isRegistered)
    {
        _firstName = firstName;
        _lastName = lastName;
        _gender = char.ToUpper(gender);
        _isRegistered = isRegistered;
    }

    public void RegisterUser(string firstName, string lastName, char gender)
    {
        _firstName = firstName;
        _lastName = lastName;
        _gender = char.ToUpper(gender);
        _isRegistered = true;
    }

    public bool IsRegistered()
    {
        return _isRegistered;
    }

    public string GetFirstName() => _firstName;
    public string GetLastName() => _lastName;
    public char GetGender() => _gender;

    public string GetFullNameDisplay()
    {
        if (!_isRegistered || string.IsNullOrWhiteSpace(_firstName))
        {
            return "";
        }
        return $"{_firstName} {_lastName}";
    }

    // Evaluates score and returns the appropriate level and title
    public (int levelNumber, string title) GetCurrentLevelAndTitle(int score)
    {
        // Unregistered user constraint: If score is 500 or more (past Level 3), 
        // and they are not registered, they get the "Less Active Member" title.
        if (!_isRegistered && score >= 500)
        {
            int theoreticalLevel = GetLevelNumberByScore(score);
            return (theoreticalLevel, "Less Active Member");
        }

        // Standard evaluation for registered users (or unregistered under 500 points)
        int levelNum = GetLevelNumberByScore(score);
        string title = GetTitleByScoreAndGender(score, levelNum, _gender);
        return (levelNum, title);
    }

    private int GetLevelNumberByScore(int score)
    {
        if (score >= 4000) return 10;
        if (score >= 3300) return 9;
        if (score >= 2700) return 8;
        if (score >= 2200) return 7;
        if (score >= 1700) return 6;
        if (score >= 1300) return 5;
        if (score >= 900) return 4;
        if (score >= 500) return 3;
        if (score >= 250) return 2;
        if (score >= 100) return 1;
        return 0;
    }

    private string GetTitleByScoreAndGender(int score, int levelNum, char gender)
    {
        switch (levelNum)
        {
            case 10:
                return (gender == 'F') ? "Relief Society Stake President" : "Stake President";
            case 9:
                return (gender == 'F') ? "Relief Society President" : "Bishop";
            case 8:
                return (gender == 'F') ? "Relief Society Counselor" : "Bishopric Counselor";
            case 7:
                return (gender == 'F') ? "Relief Society Sister" : "Elder";
            case 6:
                return (gender == 'F') ? "YW: Gatherers of Light" : "YM: Priest";
            case 5:
                return (gender == 'F') ? "YW: Messengers of Hope" : "YM: Teacher";
            case 4:
                return (gender == 'F') ? "YW: Builders of Faith" : "YM: Deacon";
            case 3:
                return "Valiant";
            case 2:
                return "C.T.R";
            case 1:
                return "Sunbeam";
            default:
                return "Nursery";
        }
    }

    public string GetSerializationString()
    {
        return $"{_isRegistered},{_firstName},{_lastName},{_gender}";
    }
}