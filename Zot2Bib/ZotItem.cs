namespace Zot2Bib;

public struct ZotItem()
{
    // Custom
    public Int64 ItemId { get; set; } = -1;

    public String? AuthorJson { get; set; } = null;

    // The remaining are auto generated.
    public String? Title { get; set; } = null;
    public String? AbstractNote { get; set; } = null;
    public String? ArtworkMedium { get; set; } = null;
    public String? Medium { get; set; } = null;
    public String? ArtworkSize { get; set; } = null;
    public String? Date { get; set; } = null;
    public String? Language { get; set; } = null;
    public String? ShortTitle { get; set; } = null;
    public String? Archive { get; set; } = null;
    public String? ArchiveLocation { get; set; } = null;
    public String? LibraryCatalog { get; set; } = null;
    public String? CallNumber { get; set; } = null;
    public String? Url { get; set; } = null;
    public String? AccessDate { get; set; } = null;
    public String? Rights { get; set; } = null;
    public String? Extra { get; set; } = null;
    public String? AudioRecordingFormat { get; set; } = null;
    public String? SeriesTitle { get; set; } = null;
    public String? Volume { get; set; } = null;
    public String? NumberOfVolumes { get; set; } = null;
    public String? Place { get; set; } = null;
    public String? Label { get; set; } = null;
    public String? Publisher { get; set; } = null;
    public String? RunningTime { get; set; } = null;
    public String? ISBN { get; set; } = null;
    public String? BillNumber { get; set; } = null;
    public String? Number { get; set; } = null;
    public String? Code { get; set; } = null;
    public String? CodeVolume { get; set; } = null;
    public String? Section { get; set; } = null;
    public String? CodePages { get; set; } = null;
    public String? Pages { get; set; } = null;
    public String? LegislativeBody { get; set; } = null;
    public String? Authority { get; set; } = null;
    public String? Session { get; set; } = null;
    public String? History { get; set; } = null;
    public String? BlogTitle { get; set; } = null;
    public String? PublicationTitle { get; set; } = null;
    public String? WebsiteType { get; set; } = null;
    public String? Type { get; set; } = null;
    public String? Series { get; set; } = null;
    public String? SeriesNumber { get; set; } = null;
    public String? Edition { get; set; } = null;
    public String? NumPages { get; set; } = null;
    public String? BookTitle { get; set; } = null;
    public String? CaseName { get; set; } = null;
    public String? Court { get; set; } = null;
    public String? DateDecided { get; set; } = null;
    public String? DocketNumber { get; set; } = null;
    public String? Reporter { get; set; } = null;
    public String? ReporterVolume { get; set; } = null;
    public String? FirstPage { get; set; } = null;
    public String? VersionNumber { get; set; } = null;
    public String? System { get; set; } = null;
    public String? Company { get; set; } = null;
    public String? ProgrammingLanguage { get; set; } = null;
    public String? ProceedingsTitle { get; set; } = null;
    public String? ConferenceName { get; set; } = null;
    public String? DOI { get; set; } = null;
    public String? Identifier { get; set; } = null;
    public String? Repository { get; set; } = null;
    public String? RepositoryLocation { get; set; } = null;
    public String? Format { get; set; } = null;
    public String? CitationKey { get; set; } = null;
    public String? DictionaryTitle { get; set; } = null;
    public String? Subject { get; set; } = null;
    public String? EncyclopediaTitle { get; set; } = null;
    public String? Distributor { get; set; } = null;
    public String? Genre { get; set; } = null;
    public String? VideoRecordingFormat { get; set; } = null;
    public String? ForumTitle { get; set; } = null;
    public String? PostType { get; set; } = null;
    public String? Committee { get; set; } = null;
    public String? DocumentNumber { get; set; } = null;
    public String? InterviewMedium { get; set; } = null;
    public String? Issue { get; set; } = null;
    public String? SeriesText { get; set; } = null;
    public String? JournalAbbreviation { get; set; } = null;
    public String? ISSN { get; set; } = null;
    public String? LetterType { get; set; } = null;
    public String? ManuscriptType { get; set; } = null;
    public String? MapType { get; set; } = null;
    public String? Scale { get; set; } = null;
    public String? Country { get; set; } = null;
    public String? Assignee { get; set; } = null;
    public String? IssuingAuthority { get; set; } = null;
    public String? PatentNumber { get; set; } = null;
    public String? FilingDate { get; set; } = null;
    public String? ApplicationNumber { get; set; } = null;
    public String? PriorityNumbers { get; set; } = null;
    public String? IssueDate { get; set; } = null;
    public String? References { get; set; } = null;
    public String? LegalStatus { get; set; } = null;
    public String? Status { get; set; } = null;
    public String? EpisodeNumber { get; set; } = null;
    public String? AudioFileType { get; set; } = null;

    public String? ArchiveID { get; set; } = null;
    public String? PresentationType { get; set; } = null;
    public String? MeetingName { get; set; } = null;
    public String? ProgramTitle { get; set; } = null;
    public String? Network { get; set; } = null;
    public String? ReportNumber { get; set; } = null;
    public String? ReportType { get; set; } = null;
    public String? Institution { get; set; } = null;
    public String? Organization { get; set; } = null;
    public String? NameOfAct { get; set; } = null;
    public String? CodeNumber { get; set; } = null;
    public String? PublicLawNumber { get; set; } = null;
    public String? DateEnacted { get; set; } = null;
    public String? ThesisType { get; set; } = null;
    public String? University { get; set; } = null;
    public String? Studio { get; set; } = null;
    public String? WebsiteTitle { get; set; } = null;

    public void SetField(String fieldName, String value)
    {
        value = value.Trim();
        var f = fieldName.ToLower();
        if (f == "itemid")
        {
            ItemId = Int64.Parse(value);
            return;
        }

        if (f == ConstStr.AuthorsJson)
        {
            AuthorJson = value;
            return;
        }

        // Below are auto generated.
        _ = f switch
        {
            "title" => Title = value,
            "abstractnote" => AbstractNote = value,
            "artworkmedium" => ArtworkMedium = value,
            "medium" => Medium = value,
            "artworksize" => ArtworkSize = value,
            "date" => Date = value,
            "language" => Language = value,
            "shorttitle" => ShortTitle = value,
            "archive" => Archive = value,
            "archivelocation" => ArchiveLocation = value,
            "librarycatalog" => LibraryCatalog = value,
            "callnumber" => CallNumber = value,
            "url" => Url = value,
            "accessdate" => AccessDate = value,
            "rights" => Rights = value,
            "extra" => Extra = value,
            "audiorecordingformat" => AudioRecordingFormat = value,
            "seriestitle" => SeriesTitle = value,
            "volume" => Volume = value,
            "numberofvolumes" => NumberOfVolumes = value,
            "place" => Place = value,
            "label" => Label = value,
            "publisher" => Publisher = value,
            "runningtime" => RunningTime = value,
            "isbn" => ISBN = value,
            "billnumber" => BillNumber = value,
            "number" => Number = value,
            "code" => Code = value,
            "codevolume" => CodeVolume = value,
            "section" => Section = value,
            "codepages" => CodePages = value,
            "pages" => Pages = value,
            "legislativebody" => LegislativeBody = value,
            "authority" => Authority = value,
            "session" => Session = value,
            "history" => History = value,
            "blogtitle" => BlogTitle = value,
            "publicationtitle" => PublicationTitle = value,
            "websitetype" => WebsiteType = value,
            "type" => Type = value,
            "series" => Series = value,
            "seriesnumber" => SeriesNumber = value,
            "edition" => Edition = value,
            "numpages" => NumPages = value,
            "booktitle" => BookTitle = value,
            "casename" => CaseName = value,
            "court" => Court = value,
            "datedecided" => DateDecided = value,
            "docketnumber" => DocketNumber = value,
            "reporter" => Reporter = value,
            "reportervolume" => ReporterVolume = value,
            "firstpage" => FirstPage = value,
            "versionnumber" => VersionNumber = value,
            "system" => System = value,
            "company" => Company = value,
            "programminglanguage" => ProgrammingLanguage = value,
            "proceedingstitle" => ProceedingsTitle = value,
            "conferencename" => ConferenceName = value,
            "doi" => DOI = value,
            "identifier" => Identifier = value,
            "repository" => Repository = value,
            "repositorylocation" => RepositoryLocation = value,
            "format" => Format = value,
            "citationkey" => CitationKey = value,
            "dictionarytitle" => DictionaryTitle = value,
            "subject" => Subject = value,
            "encyclopediatitle" => EncyclopediaTitle = value,
            "distributor" => Distributor = value,
            "genre" => Genre = value,
            "videorecordingformat" => VideoRecordingFormat = value,
            "forumtitle" => ForumTitle = value,
            "posttype" => PostType = value,
            "committee" => Committee = value,
            "documentnumber" => DocumentNumber = value,
            "interviewmedium" => InterviewMedium = value,
            "issue" => Issue = value,
            "seriestext" => SeriesText = value,
            "journalabbreviation" => JournalAbbreviation = value,
            "issn" => ISSN = value,
            "lettertype" => LetterType = value,
            "manuscripttype" => ManuscriptType = value,
            "maptype" => MapType = value,
            "scale" => Scale = value,
            "country" => Country = value,
            "assignee" => Assignee = value,
            "issuingauthority" => IssuingAuthority = value,
            "patentnumber" => PatentNumber = value,
            "filingdate" => FilingDate = value,
            "applicationnumber" => ApplicationNumber = value,
            "prioritynumbers" => PriorityNumbers = value,
            "issuedate" => IssueDate = value,
            "references" => References = value,
            "legalstatus" => LegalStatus = value,
            "status" => Status = value,
            "episodenumber" => EpisodeNumber = value,
            "audiofiletype" => AudioFileType = value,
            "archiveid" => ArchiveID = value,
            "presentationtype" => PresentationType = value,
            "meetingname" => MeetingName = value,
            "programtitle" => ProgramTitle = value,
            "network" => Network = value,
            "reportnumber" => ReportNumber = value,
            "reporttype" => ReportType = value,
            "institution" => Institution = value,
            "organization" => Organization = value,
            "nameofact" => NameOfAct = value,
            "codenumber" => CodeNumber = value,
            "publiclawnumber" => PublicLawNumber = value,
            "dateenacted" => DateEnacted = value,
            "thesistype" => ThesisType = value,
            "university" => University = value,
            "studio" => Studio = value,
            "websitetitle" => WebsiteTitle = value,

            _ => throw new($"Unknown Field {fieldName}"),
        };
    }
}
