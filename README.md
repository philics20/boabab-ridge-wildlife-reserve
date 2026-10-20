Baobab Ridge Wildlife Reserve – Animal Recovery System
A C# Windows Forms application for recording and tracking rescued animals, their recovery scores, clinical status, and housing unit. The source project uses .NET Framework 4.7.2 and the existing namespace boabab_ridge_wildlife_reserve (spelled that way in the original solution).
Features
	●	Add: Enter a unique animal ID, name, species, age and recovery score. Status and housing unit are calculated automatically from the recovery score.
	●	View: Read animal records from animals.txt and display valid entries in a read-only grid.
	●	Update: Select or find an animal and save changed details while retaining its ID.
	●	Delete: Remove an animal after a Yes/No confirmation.
	●	Summary: View the total number of animals, average age, average recovery score and counts per status.
	●	Export: Write the current summary to summary.txt next to the application executable.
	●	Error handling: Report missing-file, permission and other I/O problems without displaying a crash.
Technology and file storage
	●	C# Windows Forms, .NET Framework 4.7.2, Visual Studio
	●	Local UTF-8 pipe-delimited text files (no database)
	●	One record per line in animals.txt:
ID|Name|Species|Age|RecoveryScore|Status|HousingUnit
Example: WR-0001|Kopano|Cape Fox|3|14|Critical|Intensive Care Unit
	●	IDs use WR- followed by four digits and must be unique. Names and species must be 1–30 characters and cannot contain |. Age and score must be whole numbers from 0 through 100.
Recovery score classification

|Recovery score|Status       |Housing unit        |

|--------------|-------------|--------------------|

|0–19          |Critical     |Intensive Care Unit |

|20–39         |Serious      |High-Dependency Ward|

|40–59         |Stable       |Recovery Ward       |

|60–79         |Recovering   |Outdoor Enclosure   |

|80–100        |Release-Ready|Pre-Release Camp    |
The classification is defined in Animal.ClassifyAnimal and should not be duplicated elsewhere.
Build and run
	1.	Open boabab-ridge-wildlife-reserve.sln in Visual Studio with the .NET desktop development workload and .NET Framework 4.7.2 targeting pack installed.
	2.	Confirm that AnimalFileReader.cs, AnimalFileWriter.cs, SummaryReport.cs, FileErrorHandler.cs, and Form1.Summary.cs are included in the .csproj (the uploaded project originally omits the reader/writer).
	3.	Select animals.txt in Solution Explorer → Properties → Copy to Output Directory → Copy if newer.
	4.	Confirm all project files use compatible Animal types. Member 2 must ensure their final AnimalFileReader.cs compiles against Animal.cs before integration.
	5.	Add InitializeSummaryFeature(); immediately below InitializeComponent(); in Form1’s constructor.
	6.	Start debugging with F5. The app uses animals.txt beside the running .exe (usually bin/Debug).
	7.	Click View Summary to preview, or Export Summary to write summary.txt next to the .exe.
> `summary.txt` formatting in this package is a **proposed layout**. Check the assignment/rubric and adjust `SummaryReport.Create()` to match any exact prescribed line labels, headings or blank lines.
Example summary for the original 12-record dataset

BAOBAB RIDGE WILDLIFE RESERVE

ANIMAL RECOVERY SUMMARY REPORT

--------------------------------

Total Animals: 12

Average Age: 5.08

Average Recovery Score: 49.75

ANIMALS BY STATUS

Critical: 2

Serious: 3

Stable: 2

Recovering: 3

Release-Ready: 2
If no valid records exist, the total and counts are zero and averages display 0.00 (not NaN or a division-by-zero error). Lines that the file reader flags as malformed or duplicate are omitted from the calculations and a warning appears.
Team responsibilities / Git

|Team member|Feature branch          |Responsibility                                                                                              |

|-----------|------------------------|------------------------------------------------------------------------------------------------------------|

|1          |`feature/add-animal`    |Add form, validation, animal classification and append                                                      |

|2          |`feature/view-animals`  |Startup file loading, error-tolerant reading, read-only grid and starter data                               |

|3          |`feature/update-delete` |Selection/search, edit mode, update and delete                                                              |

|4          |`feature/summary-report`|Summaries, `summary.txt` export, reusable file error handling, README, integration and repository governance|
Make pull requests into main. Review and test each feature before merge. Member 4 should resolve integration conflicts, verify paths and confirm the final solution builds.
Manual tests before submission
	●	Launch with 12 valid records; check the example totals, averages and five status counts.
	●	Add one valid animal; re-run the report and confirm the total increases.
	●	Change an animal’s recovery score; verify that both classification and summary counts update.
	●	Delete an animal; verify that the total and counts decrease.
	●	Empty source file: total 0, averages 0.00, no divide-by-zero.
	●	Malformed/duplicate line: skipped, with a warning; no crash.
	●	Missing file: error message; do not export a misleading empty report.
	●	Read-only/inaccessible output location: error message; no success message.
	●	Close and reopen: records remain in the file.
	●	Export twice: file is regenerated from the current records, not appended to.


 