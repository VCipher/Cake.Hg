
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"NullableArgumentAttribute",
        content:"NullableArgumentAttribute",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"IdentifyCommand",
        content:"IdentifyCommand",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"MoveCommand",
        content:"MoveCommand",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"ResolveAction",
        content:"ResolveAction",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"TagAction",
        content:"TagAction",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"MercurialCommandHookArgumentsCollection",
        content:"MercurialCommandHookArgumentsCollection",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"VersionCommand",
        content:"VersionCommand",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"MercurialControllingHookBase",
        content:"MercurialControllingHookBase",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"UserConfigGuiCommand",
        content:"UserConfigGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"Changeset",
        content:"Changeset",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"MercurialPreTagHook",
        content:"MercurialPreTagHook",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"AnnotateCommand",
        content:"AnnotateCommand",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"MercurialPreCommandHook",
        content:"MercurialPreCommandHook",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"DragMoveGuiCommand",
        content:"DragMoveGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"LogEntryCopyNode",
        content:"LogEntryCopyNode",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"Client",
        content:"Client",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"HgAliases",
        content:"HgAliases",
        description:'',
        tags:''
    });

    a({
        id:17,
        title:"BundleCommand",
        content:"BundleCommand",
        description:'',
        tags:''
    });

    a({
        id:18,
        title:"ChurnUnit",
        content:"ChurnUnit",
        description:'',
        tags:''
    });

    a({
        id:19,
        title:"RemoteRepositoryPath",
        content:"RemoteRepositoryPath",
        description:'',
        tags:''
    });

    a({
        id:20,
        title:"BranchesCommand",
        content:"BranchesCommand",
        description:'',
        tags:''
    });

    a({
        id:21,
        title:"UnresolvedFilesAfterUnbundleMercurialExecutionException",
        content:"UnresolvedFilesAfterUnbundleMercurialExecutionException",
        description:'',
        tags:''
    });

    a({
        id:22,
        title:"CommandProcessor",
        content:"CommandProcessor",
        description:'',
        tags:''
    });

    a({
        id:23,
        title:"BisectGuiCommand",
        content:"BisectGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:24,
        title:"MercurialChangeGroupHook",
        content:"MercurialChangeGroupHook",
        description:'',
        tags:''
    });

    a({
        id:25,
        title:"FilesBasedGuiCommandBase",
        content:"FilesBasedGuiCommandBase",
        description:'',
        tags:''
    });

    a({
        id:26,
        title:"MercurialVersionPre",
        content:"MercurialVersionPre",
        description:'',
        tags:''
    });

    a({
        id:27,
        title:"QueueCommandBaseExtensions",
        content:"QueueCommandBaseExtensions",
        description:'',
        tags:''
    });

    a({
        id:28,
        title:"SynchronizeGuiCommand",
        content:"SynchronizeGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:29,
        title:"StripGuiCommand",
        content:"StripGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:30,
        title:"MercurialPushKeyHook",
        content:"MercurialPushKeyHook",
        description:'',
        tags:''
    });

    a({
        id:31,
        title:"MercurialPreOutgoingHook",
        content:"MercurialPreOutgoingHook",
        description:'',
        tags:''
    });

    a({
        id:32,
        title:"MercurialOutgoingHook",
        content:"MercurialOutgoingHook",
        description:'',
        tags:''
    });

    a({
        id:33,
        title:"RepeatableArgumentAttribute",
        content:"RepeatableArgumentAttribute",
        description:'',
        tags:''
    });

    a({
        id:34,
        title:"ArchiveGuiCommand",
        content:"ArchiveGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:35,
        title:"RepositorySummary",
        content:"RepositorySummary",
        description:'',
        tags:''
    });

    a({
        id:36,
        title:"IMercurialCommand",
        content:"IMercurialCommand",
        description:'',
        tags:''
    });

    a({
        id:37,
        title:"MercurialUpdateHook",
        content:"MercurialUpdateHook",
        description:'',
        tags:''
    });

    a({
        id:38,
        title:"MercurialPreTransactionCommitHook",
        content:"MercurialPreTransactionCommitHook",
        description:'',
        tags:''
    });

    a({
        id:39,
        title:"TagGuiCommand",
        content:"TagGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:40,
        title:"IAsyncResult",
        content:"IAsyncResult",
        description:'',
        tags:''
    });

    a({
        id:41,
        title:"RollbackCommand",
        content:"RollbackCommand",
        description:'',
        tags:''
    });

    a({
        id:42,
        title:"BisectResult",
        content:"BisectResult",
        description:'',
        tags:''
    });

    a({
        id:43,
        title:"CopyCommand",
        content:"CopyCommand",
        description:'',
        tags:''
    });

    a({
        id:44,
        title:"MercurialPrePushKeyHook",
        content:"MercurialPrePushKeyHook",
        description:'',
        tags:''
    });

    a({
        id:45,
        title:"QueueGuiCommand",
        content:"QueueGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:46,
        title:"TagCommand",
        content:"TagCommand",
        description:'',
        tags:''
    });

    a({
        id:47,
        title:"PurgeGuiCommand",
        content:"PurgeGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:48,
        title:"ChurnCommand",
        content:"ChurnCommand",
        description:'',
        tags:''
    });

    a({
        id:49,
        title:"MercurialTagHook",
        content:"MercurialTagHook",
        description:'',
        tags:''
    });

    a({
        id:50,
        title:"InitGuiCommand",
        content:"InitGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:51,
        title:"EmailGuiCommand",
        content:"EmailGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:52,
        title:"MPatchGuiCommand",
        content:"MPatchGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:53,
        title:"LogGuiCommand",
        content:"LogGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:54,
        title:"BisectCommand",
        content:"BisectCommand",
        description:'',
        tags:''
    });

    a({
        id:55,
        title:"StatusCommand",
        content:"StatusCommand",
        description:'',
        tags:''
    });

    a({
        id:56,
        title:"DateTimeArgumentAttribute",
        content:"DateTimeArgumentAttribute",
        description:'',
        tags:''
    });

    a({
        id:57,
        title:"ParentsCommand",
        content:"ParentsCommand",
        description:'',
        tags:''
    });

    a({
        id:58,
        title:"MergeGuiCommand",
        content:"MergeGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:59,
        title:"MoveGuiCommand",
        content:"MoveGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:60,
        title:"VerifyCommand",
        content:"VerifyCommand",
        description:'',
        tags:''
    });

    a({
        id:61,
        title:"MercurialInstallationException",
        content:"MercurialInstallationException",
        description:'',
        tags:''
    });

    a({
        id:62,
        title:"ICommand",
        content:"ICommand",
        description:'',
        tags:''
    });

    a({
        id:63,
        title:"MercurialCommandHookDataStructureBase",
        content:"MercurialCommandHookDataStructureBase",
        description:'',
        tags:''
    });

    a({
        id:64,
        title:"MercurialExecutionException",
        content:"MercurialExecutionException",
        description:'',
        tags:''
    });

    a({
        id:65,
        title:"QueueReorderGuiCommand",
        content:"QueueReorderGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:66,
        title:"MercurialCommandBase",
        content:"MercurialCommandBase",
        description:'',
        tags:''
    });

    a({
        id:67,
        title:"IMercurialCommand",
        content:"IMercurialCommand",
        description:'',
        tags:''
    });

    a({
        id:68,
        title:"BrowserGuiCommandBase",
        content:"BrowserGuiCommandBase",
        description:'',
        tags:''
    });

    a({
        id:69,
        title:"BooleanArgumentAttribute",
        content:"BooleanArgumentAttribute",
        description:'',
        tags:''
    });

    a({
        id:70,
        title:"ListFile",
        content:"ListFile",
        description:'',
        tags:''
    });

    a({
        id:71,
        title:"MergeTools",
        content:"MergeTools",
        description:'',
        tags:''
    });

    a({
        id:72,
        title:"MergeConflict",
        content:"MergeConflict",
        description:'',
        tags:''
    });

    a({
        id:73,
        title:"MergeResult",
        content:"MergeResult",
        description:'',
        tags:''
    });

    a({
        id:74,
        title:"BookmarkAction",
        content:"BookmarkAction",
        description:'',
        tags:''
    });

    a({
        id:75,
        title:"FileStatus",
        content:"FileStatus",
        description:'',
        tags:''
    });

    a({
        id:76,
        title:"InitCommand",
        content:"InitCommand",
        description:'',
        tags:''
    });

    a({
        id:77,
        title:"BackoutCommand",
        content:"BackoutCommand",
        description:'',
        tags:''
    });

    a({
        id:78,
        title:"ChangesetXmlParser",
        content:"ChangesetXmlParser",
        description:'',
        tags:''
    });

    a({
        id:79,
        title:"Bookmark",
        content:"Bookmark",
        description:'',
        tags:''
    });

    a({
        id:80,
        title:"ManifestGuiCommand",
        content:"ManifestGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:81,
        title:"ResolveCommand",
        content:"ResolveCommand",
        description:'',
        tags:''
    });

    a({
        id:82,
        title:"TipCommand",
        content:"TipCommand",
        description:'',
        tags:''
    });

    a({
        id:83,
        title:"GuiClientRequirementAttribute",
        content:"GuiClientRequirementAttribute",
        description:'',
        tags:''
    });

    a({
        id:84,
        title:"SummaryCommand",
        content:"SummaryCommand",
        description:'',
        tags:''
    });

    a({
        id:85,
        title:"MergeJob",
        content:"MergeJob",
        description:'',
        tags:''
    });

    a({
        id:86,
        title:"BookmarkCommand",
        content:"BookmarkCommand",
        description:'',
        tags:''
    });

    a({
        id:87,
        title:"RepoConfigGuiCommand",
        content:"RepoConfigGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:88,
        title:"IncomingCommand",
        content:"IncomingCommand",
        description:'',
        tags:''
    });

    a({
        id:89,
        title:"DragCopyMoveGuiCommandBase",
        content:"DragCopyMoveGuiCommandBase",
        description:'',
        tags:''
    });

    a({
        id:90,
        title:"StatusGuiCommand",
        content:"StatusGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:91,
        title:"EditIgnoreFiltersGuiCommand",
        content:"EditIgnoreFiltersGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:92,
        title:"NoChangesFoundMercurialExecutionException",
        content:"NoChangesFoundMercurialExecutionException",
        description:'',
        tags:''
    });

    a({
        id:93,
        title:"DragCopyGuiCommand",
        content:"DragCopyGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:94,
        title:"MercurialPreTransactionChangegroupHook",
        content:"MercurialPreTransactionChangegroupHook",
        description:'',
        tags:''
    });

    a({
        id:95,
        title:"UnbundleCommand",
        content:"UnbundleCommand",
        description:'',
        tags:''
    });

    a({
        id:96,
        title:"MergeJobConflict",
        content:"MergeJobConflict",
        description:'',
        tags:''
    });

    a({
        id:97,
        title:"ArchiveType",
        content:"ArchiveType",
        description:'',
        tags:''
    });

    a({
        id:98,
        title:"MercurialPostCommandHook",
        content:"MercurialPostCommandHook",
        description:'',
        tags:''
    });

    a({
        id:99,
        title:"MercurialException",
        content:"MercurialException",
        description:'',
        tags:''
    });

    a({
        id:100,
        title:"RecoveryGuiCommand",
        content:"RecoveryGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:101,
        title:"FileStatusIncludes",
        content:"FileStatusIncludes",
        description:'',
        tags:''
    });

    a({
        id:102,
        title:"ConfigurationEntry",
        content:"ConfigurationEntry",
        description:'',
        tags:''
    });

    a({
        id:103,
        title:"ShellConfigGuiCommand",
        content:"ShellConfigGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:104,
        title:"MercurialVersionBase",
        content:"MercurialVersionBase",
        description:'',
        tags:''
    });

    a({
        id:105,
        title:"MercurialPreUpdateHook",
        content:"MercurialPreUpdateHook",
        description:'',
        tags:''
    });

    a({
        id:106,
        title:"ChurnExtension",
        content:"ChurnExtension",
        description:'',
        tags:''
    });

    a({
        id:107,
        title:"MergeJobState",
        content:"MergeJobState",
        description:'',
        tags:''
    });

    a({
        id:108,
        title:"ImportGuiCommand",
        content:"ImportGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:109,
        title:"GuiClientType",
        content:"GuiClientType",
        description:'',
        tags:''
    });

    a({
        id:110,
        title:"MercurialTimeoutException",
        content:"MercurialTimeoutException",
        description:'',
        tags:''
    });

    a({
        id:111,
        title:"MercurialCommandHookPatternCollection",
        content:"MercurialCommandHookPatternCollection",
        description:'',
        tags:''
    });

    a({
        id:112,
        title:"CatCommand",
        content:"CatCommand",
        description:'',
        tags:''
    });

    a({
        id:113,
        title:"HgExtensions",
        content:"HgExtensions",
        description:'',
        tags:''
    });

    a({
        id:114,
        title:"DiffIgnores",
        content:"DiffIgnores",
        description:'',
        tags:''
    });

    a({
        id:115,
        title:"MercurialPreCommitHook",
        content:"MercurialPreCommitHook",
        description:'',
        tags:''
    });

    a({
        id:116,
        title:"AddRemoveCommand",
        content:"AddRemoveCommand",
        description:'',
        tags:''
    });

    a({
        id:117,
        title:"GuiCommandBase",
        content:"GuiCommandBase",
        description:'',
        tags:''
    });

    a({
        id:118,
        title:"HelpCommand",
        content:"HelpCommand",
        description:'',
        tags:''
    });

    a({
        id:119,
        title:"Tag",
        content:"Tag",
        description:'',
        tags:''
    });

    a({
        id:120,
        title:"ShelveGuiCommand",
        content:"ShelveGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:121,
        title:"MercurialCommandHookDictionary",
        content:"MercurialCommandHookDictionary",
        description:'',
        tags:''
    });

    a({
        id:122,
        title:"ChangesetPathAction",
        content:"ChangesetPathAction",
        description:'',
        tags:''
    });

    a({
        id:123,
        title:"CommandBase",
        content:"CommandBase",
        description:'',
        tags:''
    });

    a({
        id:124,
        title:"ArchiveCommand",
        content:"ArchiveCommand",
        description:'',
        tags:''
    });

    a({
        id:125,
        title:"RevSpec",
        content:"RevSpec",
        description:'',
        tags:''
    });

    a({
        id:126,
        title:"RebaseGuiCommand",
        content:"RebaseGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:127,
        title:"RevertGuiCommand",
        content:"RevertGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:128,
        title:"ChangesetPathActionType",
        content:"ChangesetPathActionType",
        description:'',
        tags:''
    });

    a({
        id:129,
        title:"RejectsGuiCommand",
        content:"RejectsGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:130,
        title:"LogNode",
        content:"LogNode",
        description:'',
        tags:''
    });

    a({
        id:131,
        title:"EnumArgumentAttribute",
        content:"EnumArgumentAttribute",
        description:'',
        tags:''
    });

    a({
        id:132,
        title:"BranchHead",
        content:"BranchHead",
        description:'',
        tags:''
    });

    a({
        id:133,
        title:"QueueExtension",
        content:"QueueExtension",
        description:'',
        tags:''
    });

    a({
        id:134,
        title:"RemoveCommand",
        content:"RemoveCommand",
        description:'',
        tags:''
    });

    a({
        id:135,
        title:"AddGuiCommand",
        content:"AddGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:136,
        title:"ShowConfigCommand",
        content:"ShowConfigCommand",
        description:'',
        tags:''
    });

    a({
        id:137,
        title:"BranchCommand",
        content:"BranchCommand",
        description:'',
        tags:''
    });

    a({
        id:138,
        title:"RemoteInitCommand",
        content:"RemoteInitCommand",
        description:'',
        tags:''
    });

    a({
        id:139,
        title:"RenameGuiCommand",
        content:"RenameGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:140,
        title:"MercurialCompressionType",
        content:"MercurialCompressionType",
        description:'',
        tags:''
    });

    a({
        id:141,
        title:"LogEntryTagNode",
        content:"LogEntryTagNode",
        description:'',
        tags:''
    });

    a({
        id:142,
        title:"ArgumentAttribute",
        content:"ArgumentAttribute",
        description:'',
        tags:''
    });

    a({
        id:143,
        title:"PullCommand",
        content:"PullCommand",
        description:'',
        tags:''
    });

    a({
        id:144,
        title:"IncludeExcludeCommandBase",
        content:"IncludeExcludeCommandBase",
        description:'',
        tags:''
    });

    a({
        id:145,
        title:"ForgetCommand",
        content:"ForgetCommand",
        description:'',
        tags:''
    });

    a({
        id:146,
        title:"BackoutGuiCommand",
        content:"BackoutGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:147,
        title:"MercurialHookBase",
        content:"MercurialHookBase",
        description:'',
        tags:''
    });

    a({
        id:148,
        title:"ResolveGuiCommand",
        content:"ResolveGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:149,
        title:"ClientConfigurationCollection",
        content:"ClientConfigurationCollection",
        description:'',
        tags:''
    });

    a({
        id:150,
        title:"Annotation",
        content:"Annotation",
        description:'',
        tags:''
    });

    a({
        id:151,
        title:"LogEntryAuthorNode",
        content:"LogEntryAuthorNode",
        description:'',
        tags:''
    });

    a({
        id:152,
        title:"IGuiCommand",
        content:"IGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:153,
        title:"ChurnGroup",
        content:"ChurnGroup",
        description:'',
        tags:''
    });

    a({
        id:154,
        title:"MoveCopyRenameGuiCommandBase",
        content:"MoveCopyRenameGuiCommandBase",
        description:'',
        tags:''
    });

    a({
        id:155,
        title:"MercurialVersionAttribute",
        content:"MercurialVersionAttribute",
        description:'',
        tags:''
    });

    a({
        id:156,
        title:"SearchGuiCommand",
        content:"SearchGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:157,
        title:"BookmarksCommand",
        content:"BookmarksCommand",
        description:'',
        tags:''
    });

    a({
        id:158,
        title:"GuiClient",
        content:"GuiClient",
        description:'',
        tags:''
    });

    a({
        id:159,
        title:"MergeJobConflictSubFile",
        content:"MergeJobConflictSubFile",
        description:'',
        tags:''
    });

    a({
        id:160,
        title:"HeadsCommand",
        content:"HeadsCommand",
        description:'',
        tags:''
    });

    a({
        id:161,
        title:"LogEntryPathNode",
        content:"LogEntryPathNode",
        description:'',
        tags:''
    });

    a({
        id:162,
        title:"AboutGuiCommand",
        content:"AboutGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:163,
        title:"UpdateGuiCommand",
        content:"UpdateGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:164,
        title:"TagsCommand",
        content:"TagsCommand",
        description:'',
        tags:''
    });

    a({
        id:165,
        title:"RevertCommand",
        content:"RevertCommand",
        description:'',
        tags:''
    });

    a({
        id:166,
        title:"QueueManagerGuiCommand",
        content:"QueueManagerGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:167,
        title:"CollectionExtensions",
        content:"CollectionExtensions",
        description:'',
        tags:''
    });

    a({
        id:168,
        title:"OutgoingCommand",
        content:"OutgoingCommand",
        description:'',
        tags:''
    });

    a({
        id:169,
        title:"ManifestCommand",
        content:"ManifestCommand",
        description:'',
        tags:''
    });

    a({
        id:170,
        title:"IMercurialCommandObserver",
        content:"IMercurialCommandObserver",
        description:'',
        tags:''
    });

    a({
        id:171,
        title:"CaseGuardAddRemoveCommandExtensions",
        content:"CaseGuardAddRemoveCommandExtensions",
        description:'',
        tags:''
    });

    a({
        id:172,
        title:"MoveRenameCommandBase",
        content:"MoveRenameCommandBase",
        description:'',
        tags:''
    });

    a({
        id:173,
        title:"DatamineGuiCommand",
        content:"DatamineGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:174,
        title:"MergeCommand",
        content:"MergeCommand",
        description:'',
        tags:''
    });

    a({
        id:175,
        title:"MergeConflictState",
        content:"MergeConflictState",
        description:'',
        tags:''
    });

    a({
        id:176,
        title:"CommitGuiCommand",
        content:"CommitGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:177,
        title:"CloneCommand",
        content:"CloneCommand",
        description:'',
        tags:''
    });

    a({
        id:178,
        title:"MercurialIncomingHook",
        content:"MercurialIncomingHook",
        description:'',
        tags:''
    });

    a({
        id:179,
        title:"MercurialPreListKeysHook",
        content:"MercurialPreListKeysHook",
        description:'',
        tags:''
    });

    a({
        id:180,
        title:"NamedRevision",
        content:"NamedRevision",
        description:'',
        tags:''
    });

    a({
        id:181,
        title:"RemoveGuiCommand",
        content:"RemoveGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:182,
        title:"DiffCommand",
        content:"DiffCommand",
        description:'',
        tags:''
    });

    a({
        id:183,
        title:"UpdateCommand",
        content:"UpdateCommand",
        description:'',
        tags:''
    });

    a({
        id:184,
        title:"DebugObserver",
        content:"DebugObserver",
        description:'',
        tags:''
    });

    a({
        id:185,
        title:"PathsCommand",
        content:"PathsCommand",
        description:'',
        tags:''
    });

    a({
        id:186,
        title:"GuessGuiCommand",
        content:"GuessGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:187,
        title:"PushCommand",
        content:"PushCommand",
        description:'',
        tags:''
    });

    a({
        id:188,
        title:"LogEntryNode",
        content:"LogEntryNode",
        description:'',
        tags:''
    });

    a({
        id:189,
        title:"MercurialPreChangegroupHook",
        content:"MercurialPreChangegroupHook",
        description:'',
        tags:''
    });

    a({
        id:190,
        title:"LogEntryParentNode",
        content:"LogEntryParentNode",
        description:'',
        tags:''
    });

    a({
        id:191,
        title:"AddCommand",
        content:"AddCommand",
        description:'',
        tags:''
    });

    a({
        id:192,
        title:"Repository",
        content:"Repository",
        description:'',
        tags:''
    });

    a({
        id:193,
        title:"DiffGuiCommand",
        content:"DiffGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:194,
        title:"MercurialListKeysHook",
        content:"MercurialListKeysHook",
        description:'',
        tags:''
    });

    a({
        id:195,
        title:"MercurialMissingException",
        content:"MercurialMissingException",
        description:'',
        tags:''
    });

    a({
        id:196,
        title:"MercurialResultParsingException",
        content:"MercurialResultParsingException",
        description:'',
        tags:''
    });

    a({
        id:197,
        title:"FileState",
        content:"FileState",
        description:'',
        tags:''
    });

    a({
        id:198,
        title:"CloneGuiCommand",
        content:"CloneGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:199,
        title:"CaseGuardExtension",
        content:"CaseGuardExtension",
        description:'',
        tags:''
    });

    a({
        id:200,
        title:"RenameCommand",
        content:"RenameCommand",
        description:'',
        tags:''
    });

    a({
        id:201,
        title:"LogCommand",
        content:"LogCommand",
        description:'',
        tags:''
    });

    a({
        id:202,
        title:"CopyGuiCommand",
        content:"CopyGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:203,
        title:"MercurialCommitHook",
        content:"MercurialCommitHook",
        description:'',
        tags:''
    });

    a({
        id:204,
        title:"GuiVersionCommand",
        content:"GuiVersionCommand",
        description:'',
        tags:''
    });

    a({
        id:205,
        title:"CaseGuardAddCommandExtensions",
        content:"CaseGuardAddCommandExtensions",
        description:'',
        tags:''
    });

    a({
        id:206,
        title:"CommitCommand",
        content:"CommitCommand",
        description:'',
        tags:''
    });

    a({
        id:207,
        title:"MercurialVersion",
        content:"MercurialVersion",
        description:'',
        tags:''
    });

    a({
        id:208,
        title:"IMercurialControllingHook",
        content:"IMercurialControllingHook",
        description:'',
        tags:''
    });

    a({
        id:209,
        title:"ForgetGuiCommand",
        content:"ForgetGuiCommand",
        description:'',
        tags:''
    });

    a({
        id:210,
        title:"CustomCommand",
        content:"CustomCommand",
        description:'',
        tags:''
    });

    a({
        id:211,
        title:"BisectState",
        content:"BisectState",
        description:'',
        tags:''
    });

    a({
        id:212,
        title:"RecoverCommand",
        content:"RecoverCommand",
        description:'',
        tags:''
    });

    a({
        id:213,
        title:"AnnotateGuiCommand",
        content:"AnnotateGuiCommand",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Attributes/NullableArgumentAttribute',
        title:"NullableArgumentAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IdentifyCommand',
        title:"IdentifyCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MoveCommand',
        title:"MoveCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ResolveAction',
        title:"ResolveAction",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/TagAction',
        title:"TagAction",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialCommandHookArgumentsCollection',
        title:"MercurialCommandHookArgumentsCollection",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/VersionCommand',
        title:"VersionCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialControllingHookBase',
        title:"MercurialControllingHookBase",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/UserConfigGuiCommand',
        title:"UserConfigGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/Changeset',
        title:"Changeset",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreTagHook',
        title:"MercurialPreTagHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/AnnotateCommand',
        title:"AnnotateCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreCommandHook',
        title:"MercurialPreCommandHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/DragMoveGuiCommand',
        title:"DragMoveGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogEntryCopyNode',
        title:"LogEntryCopyNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/Client',
        title:"Client",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Cake.Hg/HgAliases',
        title:"HgAliases",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BundleCommand',
        title:"BundleCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.Churn/ChurnUnit',
        title:"ChurnUnit",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RemoteRepositoryPath',
        title:"RemoteRepositoryPath",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BranchesCommand',
        title:"BranchesCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/UnresolvedFilesAfterUnbundleMercurialExecutionException',
        title:"UnresolvedFilesAfterUnbundleMercurialExecutionException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CommandProcessor',
        title:"CommandProcessor",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/BisectGuiCommand',
        title:"BisectGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialChangeGroupHook',
        title:"MercurialChangeGroupHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/FilesBasedGuiCommandBase_1',
        title:"FilesBasedGuiCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Versions/MercurialVersionPre18',
        title:"MercurialVersionPre18",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.Queues/QueueCommandBaseExtensions',
        title:"QueueCommandBaseExtensions",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/SynchronizeGuiCommand',
        title:"SynchronizeGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/StripGuiCommand',
        title:"StripGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPushKeyHook',
        title:"MercurialPushKeyHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreOutgoingHook',
        title:"MercurialPreOutgoingHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialOutgoingHook',
        title:"MercurialOutgoingHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Attributes/RepeatableArgumentAttribute',
        title:"RepeatableArgumentAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ArchiveGuiCommand',
        title:"ArchiveGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RepositorySummary',
        title:"RepositorySummary",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IMercurialCommand_1',
        title:"IMercurialCommand<TResult>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialUpdateHook',
        title:"MercurialUpdateHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreTransactionCommitHook',
        title:"MercurialPreTransactionCommitHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/TagGuiCommand',
        title:"TagGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IAsyncResult_1',
        title:"IAsyncResult<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RollbackCommand',
        title:"RollbackCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BisectResult',
        title:"BisectResult",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CopyCommand',
        title:"CopyCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPrePushKeyHook',
        title:"MercurialPrePushKeyHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/QueueGuiCommand',
        title:"QueueGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/TagCommand',
        title:"TagCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/PurgeGuiCommand',
        title:"PurgeGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.Churn/ChurnCommand',
        title:"ChurnCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialTagHook',
        title:"MercurialTagHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/InitGuiCommand',
        title:"InitGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/EmailGuiCommand',
        title:"EmailGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/MPatchGuiCommand',
        title:"MPatchGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/LogGuiCommand',
        title:"LogGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BisectCommand',
        title:"BisectCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/StatusCommand',
        title:"StatusCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Attributes/DateTimeArgumentAttribute',
        title:"DateTimeArgumentAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ParentsCommand',
        title:"ParentsCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/MergeGuiCommand',
        title:"MergeGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/MoveGuiCommand',
        title:"MoveGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/VerifyCommand',
        title:"VerifyCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialInstallationException',
        title:"MercurialInstallationException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ICommand',
        title:"ICommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialCommandHookDataStructureBase',
        title:"MercurialCommandHookDataStructureBase",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialExecutionException',
        title:"MercurialExecutionException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/QueueReorderGuiCommand',
        title:"QueueReorderGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialCommandBase_1',
        title:"MercurialCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IMercurialCommand',
        title:"IMercurialCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/BrowserGuiCommandBase_1',
        title:"BrowserGuiCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Attributes/BooleanArgumentAttribute',
        title:"BooleanArgumentAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ListFile',
        title:"ListFile",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeTools',
        title:"MergeTools",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeConflict',
        title:"MergeConflict",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeResult',
        title:"MergeResult",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BookmarkAction',
        title:"BookmarkAction",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/FileStatus',
        title:"FileStatus",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/InitCommand',
        title:"InitCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BackoutCommand',
        title:"BackoutCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ChangesetXmlParser',
        title:"ChangesetXmlParser",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/Bookmark',
        title:"Bookmark",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ManifestGuiCommand',
        title:"ManifestGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ResolveCommand',
        title:"ResolveCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/TipCommand',
        title:"TipCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/GuiClientRequirementAttribute',
        title:"GuiClientRequirementAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/SummaryCommand',
        title:"SummaryCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeJob',
        title:"MergeJob",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BookmarkCommand',
        title:"BookmarkCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RepoConfigGuiCommand',
        title:"RepoConfigGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IncomingCommand',
        title:"IncomingCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/DragCopyMoveGuiCommandBase_1',
        title:"DragCopyMoveGuiCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/StatusGuiCommand',
        title:"StatusGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/EditIgnoreFiltersGuiCommand',
        title:"EditIgnoreFiltersGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/NoChangesFoundMercurialExecutionException',
        title:"NoChangesFoundMercurialExecutionException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/DragCopyGuiCommand',
        title:"DragCopyGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreTransactionChangegroupHook',
        title:"MercurialPreTransactionChangegroupHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/UnbundleCommand',
        title:"UnbundleCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeJobConflict',
        title:"MergeJobConflict",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ArchiveType',
        title:"ArchiveType",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPostCommandHook',
        title:"MercurialPostCommandHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialException',
        title:"MercurialException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RecoveryGuiCommand',
        title:"RecoveryGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/FileStatusIncludes',
        title:"FileStatusIncludes",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ConfigurationEntry',
        title:"ConfigurationEntry",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ShellConfigGuiCommand',
        title:"ShellConfigGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Versions/MercurialVersionBase',
        title:"MercurialVersionBase",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreUpdateHook',
        title:"MercurialPreUpdateHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.Churn/ChurnExtension',
        title:"ChurnExtension",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeJobState',
        title:"MergeJobState",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ImportGuiCommand',
        title:"ImportGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/GuiClientType',
        title:"GuiClientType",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialTimeoutException',
        title:"MercurialTimeoutException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialCommandHookPatternCollection',
        title:"MercurialCommandHookPatternCollection",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CatCommand',
        title:"CatCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Cake.Hg/HgExtensions',
        title:"HgExtensions",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/DiffIgnores',
        title:"DiffIgnores",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreCommitHook',
        title:"MercurialPreCommitHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/AddRemoveCommand',
        title:"AddRemoveCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/GuiCommandBase_1',
        title:"GuiCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/HelpCommand',
        title:"HelpCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/Tag',
        title:"Tag",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ShelveGuiCommand',
        title:"ShelveGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialCommandHookDictionary',
        title:"MercurialCommandHookDictionary",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ChangesetPathAction',
        title:"ChangesetPathAction",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CommandBase_1',
        title:"CommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ArchiveCommand',
        title:"ArchiveCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RevSpec',
        title:"RevSpec",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RebaseGuiCommand',
        title:"RebaseGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RevertGuiCommand',
        title:"RevertGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ChangesetPathActionType',
        title:"ChangesetPathActionType",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RejectsGuiCommand',
        title:"RejectsGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogNode',
        title:"LogNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Attributes/EnumArgumentAttribute',
        title:"EnumArgumentAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BranchHead',
        title:"BranchHead",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.Queues/QueueExtension',
        title:"QueueExtension",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RemoveCommand',
        title:"RemoveCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/AddGuiCommand',
        title:"AddGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ShowConfigCommand',
        title:"ShowConfigCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BranchCommand',
        title:"BranchCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RemoteInitCommand',
        title:"RemoteInitCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RenameGuiCommand',
        title:"RenameGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialCompressionType',
        title:"MercurialCompressionType",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogEntryTagNode',
        title:"LogEntryTagNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Attributes/ArgumentAttribute',
        title:"ArgumentAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/PullCommand',
        title:"PullCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IncludeExcludeCommandBase_1',
        title:"IncludeExcludeCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ForgetCommand',
        title:"ForgetCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/BackoutGuiCommand',
        title:"BackoutGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialHookBase',
        title:"MercurialHookBase",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ResolveGuiCommand',
        title:"ResolveGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Configuration/ClientConfigurationCollection',
        title:"ClientConfigurationCollection",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/Annotation',
        title:"Annotation",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogEntryAuthorNode',
        title:"LogEntryAuthorNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/IGuiCommand',
        title:"IGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.Churn/ChurnGroup',
        title:"ChurnGroup",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/MoveCopyRenameGuiCommandBase_1',
        title:"MoveCopyRenameGuiCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Versions/MercurialVersionAttribute',
        title:"MercurialVersionAttribute",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/SearchGuiCommand',
        title:"SearchGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BookmarksCommand',
        title:"BookmarksCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/GuiClient',
        title:"GuiClient",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeJobConflictSubFile',
        title:"MergeJobConflictSubFile",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/HeadsCommand',
        title:"HeadsCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogEntryPathNode',
        title:"LogEntryPathNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/AboutGuiCommand',
        title:"AboutGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/UpdateGuiCommand',
        title:"UpdateGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/TagsCommand',
        title:"TagsCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RevertCommand',
        title:"RevertCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/QueueManagerGuiCommand',
        title:"QueueManagerGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CollectionExtensions',
        title:"CollectionExtensions",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/OutgoingCommand',
        title:"OutgoingCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/ManifestCommand',
        title:"ManifestCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/IMercurialCommandObserver',
        title:"IMercurialCommandObserver",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.CaseGuard/CaseGuardAddRemoveCommandExtensions',
        title:"CaseGuardAddRemoveCommandExtensions",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MoveRenameCommandBase_1',
        title:"MoveRenameCommandBase<T>",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/DatamineGuiCommand',
        title:"DatamineGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeCommand',
        title:"MergeCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MergeConflictState',
        title:"MergeConflictState",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/CommitGuiCommand',
        title:"CommitGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CloneCommand',
        title:"CloneCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialIncomingHook',
        title:"MercurialIncomingHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreListKeysHook',
        title:"MercurialPreListKeysHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/NamedRevision',
        title:"NamedRevision",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/RemoveGuiCommand',
        title:"RemoveGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/DiffCommand',
        title:"DiffCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/UpdateCommand',
        title:"UpdateCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/DebugObserver',
        title:"DebugObserver",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/PathsCommand',
        title:"PathsCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/GuessGuiCommand',
        title:"GuessGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/PushCommand',
        title:"PushCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogEntryNode',
        title:"LogEntryNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialPreChangegroupHook',
        title:"MercurialPreChangegroupHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.XmlSerializationTypes/LogEntryParentNode',
        title:"LogEntryParentNode",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/AddCommand',
        title:"AddCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/Repository',
        title:"Repository",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/DiffGuiCommand',
        title:"DiffGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialListKeysHook',
        title:"MercurialListKeysHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialMissingException',
        title:"MercurialMissingException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/MercurialResultParsingException',
        title:"MercurialResultParsingException",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/FileState',
        title:"FileState",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/CloneGuiCommand',
        title:"CloneGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.CaseGuard/CaseGuardExtension',
        title:"CaseGuardExtension",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RenameCommand',
        title:"RenameCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/LogCommand',
        title:"LogCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/CopyGuiCommand',
        title:"CopyGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/MercurialCommitHook',
        title:"MercurialCommitHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/GuiVersionCommand',
        title:"GuiVersionCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Extensions.CaseGuard/CaseGuardAddCommandExtensions',
        title:"CaseGuardAddCommandExtensions",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CommitCommand',
        title:"CommitCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Versions/MercurialVersion16',
        title:"MercurialVersion16",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Hooks/IMercurialControllingHook',
        title:"IMercurialControllingHook",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/ForgetGuiCommand',
        title:"ForgetGuiCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/CustomCommand',
        title:"CustomCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/BisectState',
        title:"BisectState",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial/RecoverCommand',
        title:"RecoverCommand",
        description:""
    });

    y({
        url:'/Cake.Hg/api/Mercurial.Gui/AnnotateGuiCommand',
        title:"AnnotateGuiCommand",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
