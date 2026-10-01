//using QuestPDF.Fluent;
//using QuestPDF.Helpers;
//using QuestPDF.Infrastructure;
//using P03R01_MC_API.Context;
//using P03R01_MC_API.Models;

//namespace P03R01_MC_API.Services
//{
//    public class PdfService : IPdfService
//    {
//        private readonly AppDbContext _context;

//        public PdfService(AppDbContext context)
//        {
//            _context = context;
//            // Licencia comunitaria gratuita de QuestPDF
//            QuestPDF.Settings.License = LicenseType.Community;
//            QuestPDF.Settings.UseSystemFonts = true;
//            QuestPDF.Settings.ThrowOnMissingFontFamilies = false;
//        }

//        /// Genera un PDF individual para el documento indicado.
//        /// Lee la configuración de impresión desde la base de datos.
//        public byte[] GenerarPdfIndividual(int documentoId)
//        {
//            // Leer configuración de impresión desde la BD
//            var config = _context.tblConfiguracionImpresion.FirstOrDefault();
//            if (config == null)
//                throw new Exception("No hay configuración de impresión registrada.");

//            // Leer el documento
//            var documento = _context.tblDocumentos.Find(documentoId);
//            if (documento == null)
//                throw new Exception("Documento no encontrado.");

//            // Generar el PDF con QuestPDF
//            var pdfBytes = Document.Create(container =>
//            {
//                container.Page(page =>
//                {
//                    // Tamaño de hoja
//                    page.Size(config.TamanoHoja switch
//                    {
//                        "A4" => PageSizes.A4,
//                        "Letter" => PageSizes.Letter,
//                        "Legal" => PageSizes.Legal,
//                        _ => PageSizes.A4
//                    });

//                    page.Margin(2, Unit.Centimetre);

//                    // Fuente y tamaño por defecto
//                    page.DefaultTextStyle(x =>
//                        x.FontSize(config.TamanoFuente)
//                         .FontFamily(config.TipoFuente));

//                    // Imagen de fondo (si existe)
//                    if (!string.IsNullOrEmpty(config.ImagenFondoBase64))
//                    {
//                        var imageBytes = Convert.FromBase64String(config.ImagenFondoBase64);
//                        page.Background().Image(imageBytes).FitArea();
//                    }

//                    // Contenido del PDF (manejo de NULLs)
//                    page.Content().Column(column =>
//                    {
//                        column.Spacing(8);

//                        column.Item().Text($"Nombre: {documento.Nombre ?? "N/A"}")
//                            .FontSize(config.TamanoFuente + 2).Bold();

//                        column.Item().Text($"Contrato: {documento.Contrato ?? "N/A"}");

//                        column.Item().Text(
//                            $"Saldo actual: " +
//                            (documento.Saldos.HasValue
//                                ? documento.Saldos.Value.ToString("C")
//                                : "N/A")
//                        );

//                        column.Item().Text($"Fecha: {documento.Fecha:dd/MM/yyyy}");

//                        column.Item().Text($"Teléfono: {documento.Telefono ?? "N/A"}");
//                    });
//                });
//            }).GeneratePdf();

//            return pdfBytes;
//        }

//        /// Genera un ZIP que contiene múltiples PDFs, uno por cada ID.

//        public byte[] GenerarZipLote(List<int> documentoIds)
//        {
//            using var zipStream = new MemoryStream();

//            using (var archive = new System.IO.Compression.ZipArchive(
//                       zipStream,
//                       System.IO.Compression.ZipArchiveMode.Create,
//                       true))
//            {
//                foreach (var id in documentoIds)
//                {
//                    var pdfBytes = GenerarPdfIndividual(id);
//                    var entry = archive.CreateEntry($"documento_{id}.pdf");

//                    using var entryStream = entry.Open();
//                    entryStream.Write(pdfBytes, 0, pdfBytes.Length);
//                }
//            }

//            zipStream.Position = 0;
//            return zipStream.ToArray();
//        }
//    }
//}

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using P03R01_MC_API.Context;
using P03R01_MC_API.Models;

namespace P03R01_MC_API.Services
{
    public class PdfService : IPdfService
    {
        private readonly AppDbContext _context;

        public PdfService(AppDbContext context)
        {
            _context = context;
            // Licencia comunitaria gratuita de QuestPDF
            QuestPDF.Settings.License = LicenseType.Community;
            QuestPDF.Settings.UseSystemFonts = true;
            QuestPDF.Settings.ThrowOnMissingFontFamilies = false;
        }

        /// Genera un PDF individual para el documento indicado.
        /// Lee la configuración de impresión desde la base de datos.
        //public byte[] GenerarPdfIndividual(int documentoId)
        //{
        //    // Leer configuración de impresión desde la BD
        //    var config = _context.tblConfiguracionImpresion.FirstOrDefault();
        //    if (config == null)
        //        throw new Exception("No hay configuración de impresión registrada.");

        //    // Leer el documento
        //    var documento = _context.tblDocumentos.Find(documentoId);
        //    if (documento == null)
        //        throw new Exception("Documento no encontrado.");

        //    // Generar el PDF con QuestPDF
        //    var pdfBytes = Document.Create(container =>
        //    {
        //        container.Page(page =>
        //        {
        //            // Tamaño de hoja
        //            page.Size(config.TamanoHoja switch
        //            {
        //                "A4" => PageSizes.A4,
        //                "Letter" => PageSizes.Letter,
        //                "Legal" => PageSizes.Legal,
        //                _ => PageSizes.A4
        //            });

        //            page.Margin(2, Unit.Centimetre);

        //            // Fuente y tamaño por defecto
        //            page.DefaultTextStyle(x =>
        //                x.FontSize(config.TamanoFuente)
        //                 .FontFamily(config.TipoFuente));

        //            // 🛡️ Imagen de fondo (si existe y es válida) — BLINDADA
        //            if (!string.IsNullOrWhiteSpace(config.ImagenFondoBase64)
        //                && config.ImagenFondoBase64.Length > 100
        //                && !config.ImagenFondoBase64.Equals("null", StringComparison.OrdinalIgnoreCase))
        //            {
        //                try
        //                {
        //                    var imageBytes = Convert.FromBase64String(config.ImagenFondoBase64);
        //                    page.Background().Image(imageBytes).FitArea();
        //                }
        //                catch (FormatException)
        //                {
        //                    // Base64 inválido → ignorar imagen de fondo (no romper el PDF)
        //                }
        //            }

        //            // Contenido del PDF (manejo de NULLs)
        //            page.Content().Column(column =>
        //            {
        //                column.Spacing(8);

        //                column.Item().Text($"Nombre: {documento.Nombre ?? "N/A"}")
        //                    .FontSize(config.TamanoFuente + 2).Bold();

        //                column.Item().Text($"Contrato: {documento.Contrato ?? "N/A"}");

        //                column.Item().Text(
        //                    $"Saldo actual: " +
        //                    (documento.Saldos.HasValue
        //                        ? documento.Saldos.Value.ToString("C")
        //                        : "N/A")
        //                );

        //                column.Item().Text($"Fecha: {documento.Fecha:dd/MM/yyyy}");

        //                column.Item().Text($"Teléfono: {documento.Telefono ?? "N/A"}");
        //            });
        //        });
        //    }).GeneratePdf();

        //    return pdfBytes;
        //}
        public byte[] GenerarPdfIndividual(int documentoId)
        {
            // Leer configuración de impresión desde la BD
            var config = _context.tblConfiguracionImpresion.FirstOrDefault();
            if (config == null)
                throw new Exception("No hay configuración de impresión registrada.");

            // Leer el documento
            var documento = _context.tblDocumentos.Find(documentoId);
            if (documento == null)
                throw new Exception("Documento no encontrado.");

            // Generar el PDF con QuestPDF
            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    // 📐 Tamaño de hoja
                    page.Size(config.TamanoHoja switch
                    {
                        "A4" => PageSizes.A4,
                        "Letter" => PageSizes.Letter,
                        "Legal" => PageSizes.Legal,
                        _ => PageSizes.A4
                    });

                    page.Margin(1.5f, Unit.Centimetre);

                    // 🔤 Fuente y tamaño por defecto
                    page.DefaultTextStyle(x =>
                        x.FontSize(config.TamanoFuente)
                         .FontFamily(config.TipoFuente)
                         .FontColor(Colors.Black));

                    // 🖼️ Imagen de fondo (si existe y es válida)
                    if (!string.IsNullOrWhiteSpace(config.ImagenFondoBase64)
                        && config.ImagenFondoBase64.Length > 100
                        && !config.ImagenFondoBase64.Equals("null", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            var imageBytes = Convert.FromBase64String(config.ImagenFondoBase64);
                            page.Background().Image(imageBytes).FitArea();
                        }
                        catch (FormatException)
                        {
                            // Base64 inválido → ignorar imagen de fondo
                        }
                    }

                    // 📝 Contenido del PDF
                    page.Content().Column(column =>
                    {
                        column.Spacing(15);

                        // ══════════════════════════════════════════
                        // 🏷️ ENCABEZADO
                        // ══════════════════════════════════════════
                        column.Item().AlignCenter().Text("Sistema MC")
                            .FontSize(config.TamanoFuente + 10)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item().AlignCenter().Text("Reporte de Documento")
                            .FontSize(config.TamanoFuente + 2)
                            .FontColor(Colors.Grey.Darken1);

                        // Línea separadora
                        column.Item().PaddingVertical(5).LineHorizontal(1)
                            .LineColor(Colors.Blue.Darken2);

                        // ══════════════════════════════════════════
                        // 👤 SECCIÓN: INFORMACIÓN DEL TITULAR
                        // ══════════════════════════════════════════
                        column.Item().PaddingTop(10).Text("INFORMACIÓN DEL TITULAR")
                            .FontSize(config.TamanoFuente + 2)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item().Background(Colors.Grey.Lighten4)
                            .Padding(10)
                            .Column(inner =>
                            {
                                inner.Spacing(5);
                                inner.Item().Text(text =>
                                {
                                    text.Span("Nombre completo: ").Bold();
                                    text.Span(documento.Nombre ?? "N/A");
                                });
                            });

                        // ══════════════════════════════════════════
                        // 📋 SECCIÓN: DATOS DEL CONTRATO
                        // ══════════════════════════════════════════
                        column.Item().PaddingTop(10).Text("DATOS DEL CONTRATO")
                            .FontSize(config.TamanoFuente + 2)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item().Background(Colors.Grey.Lighten4)
                            .Padding(10)
                            .Column(inner =>
                            {
                                inner.Spacing(5);

                                inner.Item().Text(text =>
                                {
                                    text.Span("Contrato: ").Bold();
                                    text.Span(documento.Contrato ?? "N/A");
                                });

                                inner.Item().Text(text =>
                                {
                                    text.Span("Fecha de ingreso: ").Bold();
                                    text.Span(documento.Fecha.ToString("dd/MM/yyyy"));
                                });

                                inner.Item().Text(text =>
                                {
                                    text.Span("Teléfono: ").Bold();
                                    text.Span(documento.Telefono ?? "N/A");
                                });
                            });

                        // ══════════════════════════════════════════
                        // 💰 SECCIÓN: SALDOS
                        // ══════════════════════════════════════════
                        column.Item().PaddingTop(10).Text("SALDOS")
                            .FontSize(config.TamanoFuente + 2)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item().Background(Colors.Grey.Lighten4)
                            .Padding(10)
                            .Column(inner =>
                            {
                                inner.Spacing(5);
                                inner.Item().Text(text =>
                                {
                                    text.Span("Saldo actual: ").Bold();
                                    text.Span(documento.Saldos.HasValue
                                        ? documento.Saldos.Value.ToString("C")
                                        : "N/A");
                                });
                            });

                        // ══════════════════════════════════════════
                        // 📝 SECCIÓN: OBSERVACIONES
                        // ══════════════════════════════════════════
                        column.Item().PaddingTop(10).Text("OBSERVACIONES")
                            .FontSize(config.TamanoFuente + 2)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2);

                        column.Item().Background(Colors.Grey.Lighten4)
                            .Padding(10)
                            .Text("Este documento es un reporte generado automáticamente por el Sistema MC. " +
                                  "La información contenida corresponde a los datos registrados en el sistema " +
                                  "al momento de la impresión.")
                            .FontSize(config.TamanoFuente - 1)
                            .Italic()
                            .FontColor(Colors.Grey.Darken2);

                        // ══════════════════════════════════════════
                        // 📅 PIE DE PÁGINA
                        // ══════════════════════════════════════════
                        column.Item().PaddingTop(20).LineHorizontal(1)
                            .LineColor(Colors.Grey.Lighten2);

                        column.Item().AlignCenter().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .FontSize(config.TamanoFuente - 2)
                            .FontColor(Colors.Grey.Darken1);
                    });

                    // 🦶 Footer con número de página
                    page.Footer().AlignCenter().Text(text =>
                    {
                        // Aplicar estilo por defecto a todo el bloque
                        text.DefaultTextStyle(x => x
                            .FontSize(config.TamanoFuente - 2)
                            .FontColor(Colors.Grey.Darken1));

                        text.Span("Página ");
                        text.CurrentPageNumber();
                        text.Span(" de ");
                        text.TotalPages();
                    });
                });
            }).GeneratePdf();

            return pdfBytes;
        }

        /// Genera un ZIP que contiene múltiples PDFs, uno por cada ID.
        public byte[] GenerarZipLote(List<int> documentoIds)
        {
            using var zipStream = new MemoryStream();

            using (var archive = new System.IO.Compression.ZipArchive(
                       zipStream,
                       System.IO.Compression.ZipArchiveMode.Create,
                       true))
            {
                foreach (var id in documentoIds)
                {
                    var pdfBytes = GenerarPdfIndividual(id);
                    var entry = archive.CreateEntry($"documento_{id}.pdf");

                    using var entryStream = entry.Open();
                    entryStream.Write(pdfBytes, 0, pdfBytes.Length);
                }
            }

            zipStream.Position = 0;
            return zipStream.ToArray();
        }
    }
}