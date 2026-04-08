namespace Application.Records;

public record OptionsInfo(
    int CsvColumnIndex,
    string CsvColumnName,
    int TemplateIndex,
    string TemplateField
);