Imports System.Collections.Generic
Imports System.Windows.Forms
Module Main

#Region "Variables y objetos globales"
    Public GLOBAL_NombreAplicacion As String = "CyC " & Application.ProductVersion.ToString
    Public GLOBAL_IDEmpleado As Integer
    Public GLOBAL_EmpleadoNombre As String 'Nombre del empleado
    Public GLOBAL_UsuarioNombre As String 'Nombre del usuario
    Public GLOBAL_CelulaUsuario As Short 'Célula a la que corresponde el usuario
    Public GLOBAL_CelulaDescripcion As String 'Descripción de la célula
    Public GLOBAL_IDUsuario As String
    Public GLOBAL_UsuarioNT As String
    Public GLOBAL_CajaUsuario As Byte 'Indica el número de caja del usuario
    Public GLOBAL_Database As String 'El nombre de la base de datos que se está usando
    Public GLOBAL_Servidor As String 'El nombre del servidor que se lee del archivo .inf
    Public GLOBAL_Password As String 'El password del usuario
    Public GLOBAL_DiasAjuste As Byte 'El número de días que a partir del inicio del mes, se permite ajustar el mes anterior.
    Public GLOBAL_PeriodoAjuste As Boolean 'Indica si es periodo de ajuste, es decir si es inicio de mes + DiasAjuste
    Public GLOBAL_VersionAutorizada As String 'La versión autorizada a ejecutar
    Public GLOBAL_MensajeVersion As String 'Mensaje que se presenta cuando se está ejecutando una versión desactualizada
    Public GLOBAL_CapturaPermitida As Boolean 'Indica si el usuario puede capturar movimientos
    'Public GLOBAL_UsuarioAjuste As String 'Usuario autorizado a realizar capturas de días anteriores
    Public GLOBAL_UsuarioCaptura As String 'Usuario autorizado a capturar en la ventanilla de cobranza
    'Public GLOBAL_UsuarioCancelacion As String  'Usuario autorizado a cancelar movimientos que ya estan validados
    Public GLOBAL_RutaReportes As String 'Carpeta en donde estan los reportes
    Public GLOBAL_MaxRegistrosConsulta As Integer 'Máximo de registros que se pueden consultar en la búsqueda de clientes
    'Public GLOBAL_UsuarioPuedeCancelar As Boolean 'Indica si el usuario puede cancelar
    Public GLOBAL_UsuarioCobranza As Boolean 'Indica si es un usuario que captura cobranza en la ventanilla
    Public GLOBAL_TipoMovCajaVentaGas As Byte
    Public GLOBAL_TipoMovCajaCheqDev As Byte
    'Servidor secundario para los reportes
    'Public GLOBAL_UsaServidorSecundarioRep As Boolean
    'Public GLOBAL_NombreBaseDatosReportes As String
    'Public GLOBAL_NombreServidorReportes As String
    Public GLOBAL_SeguridadNT As Boolean
    'Se agregó el 12/10/2004 para habilitar cobranza de edificios administrados
    Public GLOBAL_AplicaAdmEdificios As Boolean
    'Se agregó el 12/10/2004 para validar cobranza de edificios administrados
    Public GLOBAL_TipoMovimientoAdmEdificios As Byte
    Public GLOBAL_RamoAdmEdificios As String
    Public GLOBAL_ClientePadreEdificio As Integer
    Public GLOBAL_AplicaValidacionClienteHijo As Boolean
    Public GLOBAL_NoAbonarClientePadreEdificio As Boolean

    'Habilita la validación de la aplicación de notas de crédito
    Public GLOBAL_AplicaValidaciónNotaCredito As Boolean

    'Cadena de conexión para exportación de cargos
    Public GLOBAL_CadenaConexionExport As String

    Public GLOBAL_UsuarioReportes As String
    Public GLOBAL_PasswordReportes As String

    'Transferencias bancarias
    'Indica sí se activa la captura de datos completos de transferencias bancarias
    Public GLOBAL_TransferenciaActiva As Boolean
    'Tipo de movimiento de caja para transferencias bancarias
    Public GLOBAL_TipoMovimientoTransferencia As Short

    'Control de saldos a favor 
    'Indica si se activa la captura de saldos a favor
    Public GLOBAL_SaldoAFavorActivo As Boolean
    Public GLOBAL_AplicacionSaldoAFavor As Boolean
    'Valor minimo para saldo a favor
    Public GLOBAL_ValorMinimoSaldoAFavor As Double
    'Tipo de movimiento para aplicar saldos a favor
    Public GLOBAL_TipoMovimientoSaldoAFavor As Short
    Public GLOBAL_MaxSaldosAFavorAplParcialPendiente As Short

    Public GLOBAL_BusquedaPorValeCredito As Boolean

    'Solo generar abonos para importes exactos
    Public GLOBAL_PGREFImporteExacto As Boolean

    'Para cargar la lista de cobranza de los clientes que no tienen datos de programación completos
    Public GLOBAL_CargaClientesSinDatosPrg As Boolean

    'Para validar la longitud del número de cuenta de los cheques capturados
    Public GLOBAL_MinLenCuenta, GLOBAL_MaxLenCuenta As Byte

    Public CapturaMixtaEfectivoVales As Boolean = False 'Indica si el cobro que se está capturando es mixto.
    Public Const M_ESTAN_CORRECTOS As String = "¿Estan correctos los datos?"
    Public Const M_DATOS_OK As String = "Los datos fueron grabados correctamente."
    Public Const M_ACCESO As String = "No tiene acceso a esta opción."
    Public CapturaEfectivoVales As Boolean = False 'Indica si ya se capturo un cobro con efectivo o con vales.

    Public ConsecutivoInicioDeSesion As Byte 'Indica el número de consecutivo que el inicio de sesión tiene
    Public ConString As String

    Public FechaOperacion As Date 'Indica la fecha de operación actual DEL SERVIDOR en formato (dd/MM/yyyy)
    Public FechaInicioSesion As Date
    Public SesionIniciada As Boolean = False
    Public PuedeIniciarSesion As Boolean = True
    Public oSeguridad As SigaMetClasses.cSeguridad

    Public GLOBAL_connection As SqlClient.SqlConnection

    Public DTListaBancos As New System.Data.DataTable("ListaBancos")
    Public DSCatalogos As New DataSet("Catalogos")

    'Autorización de crédito del cliente
    Public GLOBAL_ClaveCreditoAutorizado As Byte
    Public GLOBAL_MaxImporteCredito As Decimal
    Public GLOBAL_CapturaCobranzaAtrasada As Boolean

    'Cierre de las relaciones de cobranza de ejecutivo
    Public GLOBAL_AutCierreRelEjeCyC As Boolean
    Public GLOBAL_RCCaptDocumentoPagado As Boolean

    'Ajuste de eficincias negativas
    Public GLOBAL_TipoCargoEfiNeg As Byte

    'Formato de la consulta de saldos de pedidos, todos los decimales o formato numérico
    Public GLOBAL_FormatoCapturaSaldos As Boolean

    'Parámetros para resguardo de créditos
    'Número de empleado del responsable de resguardo
    Public GLOBAL_RespResguardo As Integer
    'Número de empleado del responsable de resguardo crédito operador
    Public GLOBAL_RespResguardoOP As Integer
    'Número de empleado del responsable de resguardo crédito CyC
    Public GLOBAL_RespResguardoCyC As Integer
    '**

    'Parámetro para controlar la entrega de documentos al cierre de listas de cobranza
    Public GLOBAL_DevDocumentosReq As Boolean
    '**

    'Número de las listas de cobranza de documentos no devueltos a resguardo
    Public GLOBAL_ListaDevCobrador As Byte
    Public GLOBAL_ListaDevEjecutivo As Byte
    '****

    'Validar el consecutivo del cheque al capturar cobros
    Public GLOBAL_ValidarConsCheque As Boolean

    'Validar el cliente del cheque al capturar pedidos
    Public GLOBAL_ValidarClienteCheque As Boolean

    'Control de cheques posfechados
    Public GLOBAL_Posfechado As Boolean

    'Control de cheques posfechados
    Public GLOBAL_LimitePosfechado As Long

    'Control de notas de ingreso
    'Restricción para captura de notas de ingreso
    Public GLOBAL_SoloNICapturada As Boolean
    'Validación de notas de ingreso (Validadas y Capturadas previamente)
    Public GLOBAL_ValidarNI As Boolean
    '*****

    'Validación de tipo de cobro en el tipo de movimiento
    Public GLOBAL_ValidarTipoCobro As Boolean

    'Corporativo y sucursal para la carga de parámetros múltiples
    Public GLOBAL_Corporativo As Short
    Public GLOBAL_Sucursal As Short
    '*****

    'Nombre de la empresa en la que está corriendo la aplicación
    Public GLOBAL_NombreEmpresa As String

    'Código del empleado utilizado para identificar abonos externos
    Public GLOBAL_EmpleadoAbonoExterno As Integer

    Public GLOBAL_Modulo As Short = 4
    Public GLOBAL_Empresa As Short

#End Region

#Region "Variables globales para la Seguridad"
    'Public SEG_Acceso As Boolean
    'Public SEG_Reportes As Boolean
    'Public SEG_Movimientos As Boolean
    'Public SEG_BusquedaClientes As Boolean
    'Public SEG_Relaciones As Boolean
    'Public SEG_SysAdmin As Boolean
    'Public SEG_CambioPassword As Boolean
    'Public SEG_Facturas As Boolean
    'Public SEG_Documentos As Boolean
    'Public SEG_Empresas As Boolean
    'Public SEG_Cheques As Boolean
    'Public SEG_Relaciones_Captura_Own As Boolean
    'Public SEG_Relaciones_Captura_Full As Boolean
    'Public SEG_Relaciones_Modifica_Own As Boolean
    'Public SEG_Relaciones_Modifica_Full As Boolean
    'Public SEG_Relaciones_Cierra_Own As Boolean
    'Public SEG_Relaciones_Cierra_Full As Boolean
    'Public SEG_Relaciones_Cancela_Own As Boolean
    'Public SEG_Relaciones_Cancela_Full As Boolean
    'Public SEG_Relaciones_Imprime_Own As Boolean
    'Public SEG_Relaciones_Imprime_Full As Boolean
    'Public SEG_Movimientos_Captura As Boolean
    'Public SEG_Movimientos_Cancela_Own As Boolean
    'Public SEG_Movimientos_Cancela_Full As Boolean
    'Public SEG_Movimientos_Revive As Boolean
    'Public SEG_Movimientos_CobroModifica_Own As Boolean
    'Public SEG_Movimientos_CobroModifica_Full As Boolean
    'Public SEG_Operadores As Boolean
    'Public SEG_Operadores_Modifica As Boolean
    'Public SEG_TarjetasCredito As Boolean
    'Public SEG_CatMotivoCancelaMov As Boolean
    'Public SEG_CatMotivoCancelaMov_Captura As Boolean
    'Public SEG_ClientesCartera As Boolean
    'Public SEG_ClientesCartera_Modifica As Boolean
#End Region

#Region "IniciarSesion"
    Public Sub IniciarSesion(ByRef FechaInicioDeSesion As DateTime)
        If SesionIniciada Then
            MessageBox.Show("La sesión ya fue iniciada.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        If Not PuedeIniciarSesion Then
            MessageBox.Show("No puede iniciar sesión.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            FechaInicioDeSesion = Now
            ConsecutivoInicioDeSesion = CType(oCorte.Alta(GLOBAL_CajaUsuario, FechaOperacion, GLOBAL_IDUsuario, FechaInicioDeSesion), Byte)
            SesionIniciada = True
        Catch ex As Exception
            SesionIniciada = False
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub
#End Region

#Region "TerminarSesion"
    Public Sub TerminarSesion()
        If Not SesionIniciada Then
            MessageBox.Show("La sesión no ha sido iniciada.", "Termino de sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            oCorte.TerminaSesion(GLOBAL_CajaUsuario, CType(Today.ToShortDateString, Date), ConsecutivoInicioDeSesion, Now, "MVargas")
            SesionIniciada = False
        Catch ex As Exception
            SesionIniciada = True
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub
#End Region

#Region "Control de listas de cobranza"
    Public Enum TipoCapturaCobranza
        Captura = 1
        Precaptura = 2
        Entrega = 3
    End Enum
#End Region

    Public TipoSeguridad As SigametSeguridad.UI.TipoSeguridad

    Public Sub Main()

        Dim oSplash As New frmSplash()
        oSplash.ShowDialog()

        Try

            Dim frmAcceso As New SigametSeguridad.UI.Acceso(Application.StartupPath + "\Default.Seguridad y administracion.exe.config", _
        True, 4, New Bitmap(Application.StartupPath + "\ModuloCyC.ico"))

            If frmAcceso.ShowDialog = DialogResult.OK Then

                Dim oLogin As New SigaMetClasses.Seguridad(4, frmAcceso.CadenaConexion, frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada)

                GLOBAL_IDUsuario = oLogin.UserID

                'Corporativo y sucursal para carga de parámetros duplicados
                GLOBAL_Corporativo = oLogin.Corporativo
                GLOBAL_Sucursal = oLogin.Sucursal
                '*****

                'El objeto oSeguridad ya queda público y puede ser usado desde cualquier parte
                oSeguridad = New SigaMetClasses.cSeguridad(GLOBAL_IDUsuario, 4)
                If Not oSeguridad.TieneAcceso("Acceso") Then
                    If Not (oSeguridad.TieneAcceso("SysAdmin")) Then
                        MessageBox.Show("Usted no tiene permiso para usar este módulo.", "Módulo de CyC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Try
                    FechaOperacion = SigaMetClasses.FechaServidor.Date
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End Try


                GLOBAL_Database = oLogin.BaseDatos
                GLOBAL_Servidor = oLogin.Servidor
                GLOBAL_Password = oLogin.Password
                GLOBAL_UsuarioNT = oLogin.UsuarioNT
                GLOBAL_IDEmpleado = oLogin.Empleado
                GLOBAL_EmpleadoNombre = oLogin.EmpleadoNombre
                GLOBAL_UsuarioNombre = oLogin.UsuarioNombre
                GLOBAL_CelulaUsuario = oLogin.Celula
                GLOBAL_CelulaDescripcion = oLogin.CelulaDescripcion
                GLOBAL_CajaUsuario = oLogin.Caja
                GLOBAL_SeguridadNT = oLogin.SeguridadNT
                ConString = oLogin.CadenaConexion

                If GLOBAL_CajaUsuario = 0 Then
                    GLOBAL_CapturaPermitida = False
                Else
                    GLOBAL_UsuarioCobranza = oLogin.Cobranza
                    GLOBAL_CapturaPermitida = True
                End If

                'Parámetros del módulo
                Try
                    GLOBAL_DiasAjuste = CType(oLogin.Parametros("DiasAjuste"), Byte)
                    GLOBAL_VersionAutorizada = CType(oLogin.Parametros("VersionAutorizada"), String)
                    GLOBAL_MensajeVersion = CType(oLogin.Parametros("MensajeVersion"), String)
                    'GLOBAL_UsuarioAjuste = CType(oLogin.Parametros("UsuarioAjuste"), String)
                    GLOBAL_UsuarioCaptura = CType(oLogin.Parametros("UsuarioCaptura"), String)
                    'GLOBAL_UsuarioCancelacion = CType(oLogin.Parametros("UsuarioCancelacion"), String)
                    'GLOBAL_RutaReportes = CType(oLogin.Parametros("RutaReportes"), String)

                    GLOBAL_RutaReportes = _
                        CType(SigametSeguridad.Seguridad.Parametros(4, CType(GLOBAL_Corporativo, Byte), _
                        CType(GLOBAL_Sucursal, Byte)).ValorParametro("RutaReportesW7"), String)

                    GLOBAL_MaxRegistrosConsulta = CType(oLogin.Parametros("MaxRegistrosConsulta"), Integer)
                    GLOBAL_TipoMovCajaVentaGas = CType(oLogin.Parametros("TipoMovCajaVentaGas"), Byte)
                    GLOBAL_TipoMovCajaCheqDev = CType(oLogin.Parametros("TipoMovCajaCheqDev"), Byte)
                    'GLOBAL_UsaServidorSecundarioRep = CType(oLogin.Parametros("UsaServidorSecundarioRep"), Boolean)
                    'GLOBAL_NombreBaseDatosReportes = CType(oLogin.Parametros("NombreBaseDatosReportes"), String)
                    'GLOBAL_NombreServidorReportes = CType(oLogin.Parametros("NombreServidorReportes"), String)
                    'TODO: Se agregó el 12/10/2004 para habilitar y validar la cobranza de administración de edificios
                    GLOBAL_AplicaAdmEdificios = CType(oLogin.Parametros("AplicaAdmEdificios"), Boolean)
                    'Se agregó el 12/10/2004 para validar cobranza de edificios administrados
                    If GLOBAL_AplicaAdmEdificios Then
                        GLOBAL_TipoMovimientoAdmEdificios = CType(oLogin.Parametros("TipoMovCajaAdmEdificios"), Byte)
                        GLOBAL_RamoAdmEdificios = CType(oLogin.Parametros("RamoAdmEdificios"), String)
                        'TODO: Poner como operación en perfil
                        GLOBAL_NoAbonarClientePadreEdificio = CType(oLogin.Parametros("NoAbonarAClientePadreEdif"), Boolean)
                    End If

                    GLOBAL_AplicaValidaciónNotaCredito = CType(oLogin.Parametros("ValidaAplicacionNotaCredi"), Boolean)

                    'Para usar el usuario y password del usuario de reportes
                    consultaParametrosConexionReportesEspeciales(SigaMetClasses.DataLayer.Conexion)
                    GLOBAL_CadenaConexionExport = "Data Source=" & CStr(oLogin.Parametros("NombreServidorReportes")) & ";Initial Catalog=" & _
                        CStr(oLogin.Parametros("NombreBaseDatosReportes")) & ";UID=" & GLOBAL_UsuarioReportes & _
                        ";Password=" & GLOBAL_PasswordReportes & ";"

                    'Se agregó para el control de transferencias bancarias
                    GLOBAL_TransferenciaActiva = CType(oLogin.Parametros("TransferenciaActiva"), Boolean)
                    GLOBAL_TipoMovimientoTransferencia = CType(oLogin.Parametros("TipoMovTransferencia"), Short)
                    'Se agregó para el control de saldos a favor
                    GLOBAL_SaldoAFavorActivo = CType(oLogin.Parametros("SaldoAFavorActivo"), Boolean)
                    GLOBAL_AplicacionSaldoAFavor = CType(oLogin.Parametros("AplicacionSaldoAFavor"), Boolean)
                    GLOBAL_ValorMinimoSaldoAFavor = CType(oLogin.Parametros("SaldoAFavorMinimo"), Double)
                    GLOBAL_TipoMovimientoSaldoAFavor = CType(oLogin.Parametros("TipoMovimientoSaldoAFavor"), Short)
                    GLOBAL_MaxSaldosAFavorAplParcialPendiente = CType(oLogin.Parametros("MaximoSaldosAFavor"), Short)

                    GLOBAL_BusquedaPorValeCredito = CType(oLogin.Parametros("BusquedaValeCredito"), Boolean)

                    GLOBAL_PGREFImporteExacto = CType(oLogin.Parametros("PGREFImporteExacto"), Boolean)

                    GLOBAL_CargaClientesSinDatosPrg = CType(oLogin.Parametros("PROGCOBCLIENTESINDATOS"), Boolean)

                    GLOBAL_MinLenCuenta = CType(oLogin.Parametros("MinLongitudNoCuenta"), Byte)
                    GLOBAL_MaxLenCuenta = CType(oLogin.Parametros("MaxLongitudNoCuenta"), Byte)

                    'Autorización de crédito
                    GLOBAL_ClaveCreditoAutorizado = CType(oLogin.Parametros("ClaveCreditoAutorizado"), Byte)
                    GLOBAL_MaxImporteCredito = CType(oLogin.Parametros("MaxImporteCredito"), Decimal)
                    GLOBAL_CapturaCobranzaAtrasada = CType(oLogin.Parametros("CAPTURA_COBRANZAATRASADA"), Boolean)

                    'Relaciones de cobranza
                    GLOBAL_AutCierreRelEjeCyC = CType(oLogin.Parametros("AUT_CIERRERELEJECYC"), Boolean)
                    GLOBAL_RCCaptDocumentoPagado = CType(oLogin.Parametros("RELCOB_CAPTDOCPAGADO"), Boolean)

                    'Ajuste de eficiencias negativas
                    GLOBAL_TipoCargoEfiNeg = CType(oLogin.Parametros("TipoCargoEficiencia"), Byte)

                    'Formato de consulta de saldos
                    GLOBAL_FormatoCapturaSaldos = CType(oLogin.Parametros("FormatearSaldosCapt"), Boolean)

                    'Parametros para resguardo de CyC
                    'Responsable de resguardo créditos OP
                    GLOBAL_RespResguardoOP = CType(oLogin.Parametros("RespResgCOP"), Integer)
                    'Responsable de resguardo créditos CyC
                    GLOBAL_RespResguardoCyC = CType(oLogin.Parametros("RespResgCCyC"), Integer)
                    'Rsponsable de resguardo (Bóveda)
                    GLOBAL_RespResguardo = CType(oLogin.Parametros("RespResguardo"), Integer)
                    '**

                    'Parámetros para control de devolución de documentos a resguardo
                    GLOBAL_DevDocumentosReq = CType(oLogin.Parametros("DevDocumentosResg"), Boolean)
                    '**

                    'Listas de cobranza de documentos no devueltos a resguardo
                    GLOBAL_ListaDevCobrador = CType(oLogin.Parametros("RelCobNoDevCobrador"), Byte)
                    GLOBAL_ListaDevEjecutivo = CType(oLogin.Parametros("RelCobNoDevEjeCyC"), Byte)
                    '****

                    'Validar el consecutivo del cheque al capturar cobros
                    GLOBAL_ValidarConsCheque = CType(oLogin.Parametros("ValidarConsCheque"), Boolean)

                    'Validar el cliente del cheque
                    GLOBAL_ValidarClienteCheque = CType(oLogin.Parametros("ValidarClienteCheque"), Boolean)

                    'Control de cheques posfechados
                    GLOBAL_Posfechado = CType(oLogin.Parametros("Posfechado"), Boolean)
                    '-----
                    GLOBAL_LimitePosfechado = CType(oLogin.Parametros("DiasLimPosfechado"), Long)
                    '*****

                    'Control de notas de ingreso
                    'solo notas de ingreso precapturadas
                    GLOBAL_SoloNICapturada = CType(oLogin.Parametros("SoloNICapturada"), Boolean)
                    'validar capturas anteriores y que la nota de crédito esté validada
                    GLOBAL_ValidarNI = CType(oLogin.Parametros("ValidarCapturaNI"), Boolean)
                    '*****

                    'Validar que el tipo de cobro sea permitido para el tipo de movimiento que se está capturando
                    GLOBAL_ValidarTipoCobro = CType(oLogin.Parametros("ValidarTipoCobro"), Boolean)

                    'Código del empleado que será utilizado para identificar los abonos externos
                    GLOBAL_EmpleadoAbonoExterno = CType(oLogin.Parametros("EmpleadoAbonosExternos"), Integer)

                    'Nombre de la empresa en la que está corriendo la aplicación
                    Dim _datosEmpresa As New NombreEmpresa.DatosEmpresa()
                    GLOBAL_NombreEmpresa = _datosEmpresa.NombreEmpresa
                Catch ArgEx As ArgumentException
                    MessageBox.Show("El sistema no puede leer la información del parámetro.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

                'If GLOBAL_UsuarioCancelacion = GLOBAL_IDUsuario Then
                '    GLOBAL_UsuarioPuedeCancelar = True
                'End If

                'If GLOBAL_VersionAutorizada <> Application.ProductVersion.ToString Then
                '    MessageBox.Show(GLOBAL_MensajeVersion, "Módulo de CyC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Exit Sub
                'End If

                'IMPLEMENTACIÓN DEL UpDATER (ACTUALIZACION AUTOMÁTICA) 14/09/2004
                GLOBAL_connection = SigaMetClasses.DataLayer.Conexion
                Dim updateSys As New SIGAMETSecurity.Updater(4, Application.ProductVersion, Application.StartupPath, frmAcceso.CadenaConexion)
                If updateSys.Desactualizado = True Then
                    'Necesita actualizarse
                    Application.Exit()
                    Exit Sub
                End If

                'Carga de la lista de bancos y cuentas bancarias
                cargaListaBancos(GLOBAL_connection)
                CargaCatalogos(GLOBAL_connection)

                'Explicitly set apartment state to Single Thread Apartment (STA)
                System.Threading.Thread.CurrentThread.SetApartmentState(Threading.ApartmentState.STA)
                Dim eh As New CustomExceptionHandler()
                AddHandler Application.ThreadException, AddressOf eh.OnThreadException
                Application.Run(New frmPrincipal())

            End If

        Catch Ex As Exception
            'MessageBox.Show(Application.StartupPath + "\ModuloCyC.ico")
            MessageBox.Show(Ex.Message, Ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Friend Class CustomExceptionHandler
        ' The Error Handler class
        ' We need a class because event handling methods can't be static
        ' Handle the exception event
        Public Sub OnThreadException(ByVal Sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)

            Dim result As DialogResult = DialogResult.Cancel
            Try
                result = Me.ShowThreadExceptionDialog(t.Exception)
            Catch ex As Exception
                Try
                    EventLog.WriteEntry("CyC", ex.Message, EventLogEntryType.Error)
                    MessageBox.Show(ex.Message, "Error en el módulo", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
                Finally
                    Application.Exit()
                End Try
            End Try

            If (result = DialogResult.Abort) Then
                Application.Exit()
            End If
        End Sub


        ' The simple dialog that is displayed when this class catches and exception
        Private Function ShowThreadExceptionDialog(ByVal e As Exception) As DialogResult
            Dim errorMsg As String = "Ha ocurrido un error.  Por favor contacte al administrador del " & _
                                     "sistema con la siguiente información:" & vbCrLf & vbCrLf
            errorMsg &= e.Message & vbCrLf & vbCrLf & "Stack Trace:" & _
                        vbCrLf & e.StackTrace
            Return MessageBox.Show(errorMsg, _
                                    "Error en la aplicación", _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Stop)
        End Function
    End Class

    Private Sub CargaCatalogos(ByVal Connection As System.Data.SqlClient.SqlConnection)
        Dim data As New SGDAC.DAC(Connection)
        DSCatalogos.Tables.Add("Celulas")
        DSCatalogos.Tables.Add("EjecutivosCyC")
        DSCatalogos.Tables.Add("Rutas")
        Try
            data.LoadData(DSCatalogos.Tables("Celulas"), "spSGCConsultaCelulas", CommandType.StoredProcedure, False)
            data.LoadData(DSCatalogos.Tables("Rutas"), "spSGCConsultaRutas", CommandType.StoredProcedure, False)
            data.LoadData(DSCatalogos.Tables("EjecutivosCyC"), "spCyCConsultaEjecutivos", CommandType.StoredProcedure, False)
        Catch ex As Exception
            MessageBox.Show("No fué posible la carga de catálogos" & Chr(13) & _
            ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargaListaBancos(ByVal Connection As System.Data.SqlClient.SqlConnection)
        Dim data As New SGDAC.DAC(Connection)
        Try
            data.LoadData(DTListaBancos, "spCyCPGRefConsultaBancos", CommandType.StoredProcedure, True)
            DTListaBancos.Columns.Add("NombreCompuesto")
            Dim dr As DataRow
            For Each dr In DTListaBancos.Rows
                dr.BeginEdit()
                dr("Cuenta") = CStr(dr("Cuenta")).Trim
                dr("BancoNombre") = CStr(dr("BancoNombre")).Trim
                dr("NombreCompuesto") = CStr(dr("Cuenta")).Trim & " - " & CStr(dr("BancoNombre")).Trim
                dr.EndEdit()
            Next
        Catch ex As Exception
            EventLog.WriteEntry(ex.Source, ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Public Function cargaListaAfiliaciones(ByVal Connection As System.Data.SqlClient.SqlConnection) As Dictionary(Of Int32, String)
        Dim Diccionario As New Dictionary(Of Int32, String)
        Dim dtAfiliaciones As New DataTable()
        Dim data As New SGDAC.DAC(Connection)
        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Ruta", DBNull.Value)
        Try
            data.LoadData(dtAfiliaciones, "spLiqConsultaAfiliacion", CommandType.StoredProcedure, param, True)
            Dim dr As DataRow
            For Each dr In dtAfiliaciones.Rows
                Diccionario.Add(Convert.ToInt32(dr(0)), Convert.ToString(dr(1)))
            Next
        Catch ex As Exception
            EventLog.WriteEntry(ex.Source, ex.Message, EventLogEntryType.Error)
        End Try
        Return Diccionario
    End Function

    Public Function cargaListaBancosTC(ByVal Connection As System.Data.SqlClient.SqlConnection) As Dictionary(Of Int32, String)
        Dim Diccionario As New Dictionary(Of Int32, String)
        Dim dtBancosTC As New DataTable()
        Dim data As New SGDAC.DAC(Connection)

        Try
            data.LoadData(dtBancosTC, "spLIQ2ConsultaBancos", CommandType.StoredProcedure, True)
            Dim dr As DataRow
            For Each dr In dtBancosTC.Rows
                Diccionario.Add(Convert.ToInt32(dr(0)), Convert.ToString(dr(1)))
            Next
        Catch ex As Exception
            EventLog.WriteEntry(ex.Source, ex.Message, EventLogEntryType.Error)
        End Try
        Return Diccionario
    End Function


    Friend Function consultaMovimientoCobranza(ByVal Connection As System.Data.SqlClient.SqlConnection, _
            ByVal Clave As String) As DataTable
        Dim data As New SGDAC.DAC(Connection)
        Dim dtMovimientoCaja As New DataTable("DatosMovimiento")

        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Clave", Clave)
        Try
            data.LoadData(dtMovimientoCaja, "spCyCConsultaDatosMovimiento", CommandType.StoredProcedure, param, True)
        Catch ex As Exception
            Throw ex
        End Try
        Return dtMovimientoCaja
    End Function

    Private Sub consultaParametrosConexionReportesEspeciales(ByVal Connection As System.Data.SqlClient.SqlConnection)
        Dim alterConfig As SigaMetClasses.cConfig = New SigaMetClasses.cConfig(9)
        GLOBAL_UsuarioReportes = CStr(alterConfig.Parametros("UsuarioReportes")).Trim
        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(GLOBAL_UsuarioReportes)
        GLOBAL_PasswordReportes = oUsuarioReportes.Password
    End Sub

    Public Function requiereAutorizacionCierre(ByVal Connection As SqlClient.SqlConnection, ByVal TipoCobranza As Byte) As Boolean
        Dim _retVal As Boolean = False
        Dim data As New SGDAC.DAC(Connection)
        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@TipoCobranza", TipoCobranza)
        Try
            _retVal = CType(data.LoadScalarData("spCyCRelacionDeCobranzaParaAutorizacionCierre", CommandType.StoredProcedure, param), Boolean)
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try
        Return _retVal
    End Function

    'Validación de privilegios para captura de cobranza
    Public Function AutorizaCapturaCobranza(ByVal TipoCobranza As Byte) As Boolean
        Dim permitirCaptura As Boolean = True
        Select Case CType(TipoCobranza, Byte)
            Case 1
                If Not oSeguridad.TieneAcceso("CAPT_REL_COBRADOR") Then
                    permitirCaptura = False
                End If
            Case 2
                If Not oSeguridad.TieneAcceso("CAPT_REL_EJE_CYC") Then
                    permitirCaptura = False
                End If
            Case 3
                If Not oSeguridad.TieneAcceso("CAPT_REL_OPERADOR") Then
                    permitirCaptura = False
                End If
            Case 4
                If Not oSeguridad.TieneAcceso("CAPT_REL_VENTCYC") Then
                    permitirCaptura = False
                End If
            Case 5
                If Not oSeguridad.TieneAcceso("CAPT_REL_TDC") Then
                    permitirCaptura = False
                End If
            Case 6
                If Not oSeguridad.TieneAcceso("CAPT_REL_AUDITCYC") Then
                    permitirCaptura = False
                End If
            Case 7
                If Not oSeguridad.TieneAcceso("CAPT_REL_EJE_CYC_RESG") Then
                    permitirCaptura = False
                End If
            Case 8
                If Not oSeguridad.TieneAcceso("CAPT_REL_JURIDICO") Then
                    permitirCaptura = False
                End If
            Case 9
                If Not oSeguridad.TieneAcceso("CAPT_REL_RESG_CYC") Then
                    permitirCaptura = False
                End If
            Case 10
                If Not oSeguridad.TieneAcceso("CAPT_REL_EJE_CYC_PLAN") Then
                    permitirCaptura = False
                End If
            Case 11
                If Not oSeguridad.TieneAcceso("CAPT_REL_RESG_COB") Then
                    permitirCaptura = False
                End If
            Case 12
                If Not oSeguridad.TieneAcceso("CAPT_REL_RESG_EJECYC") Then
                    permitirCaptura = False
                End If
            Case 13
                If Not oSeguridad.TieneAcceso("CAPT_REL_RESG_CHEQDEV") Then
                    permitirCaptura = False
                End If
            Case 14 'Lista de cobranza para archivo muerto
                If Not oSeguridad.TieneAcceso("CAPT_REL_ARCH_MUERTO") Then
                    permitirCaptura = False
                End If
        End Select
        Return permitirCaptura
    End Function

    'Validación del tipo de cargo en captura de cobranza
    Public Function TipoCargoCobranza(ByVal Connection As SqlClient.SqlConnection, ByVal TipoCobranza As Byte) As DataTable
        Dim dtTipoCargo As DataTable = New DataTable("TipoCargoTipoCobranza")
        dtTipoCargo.Columns.Add("TipoCargo")

        dtTipoCargo.PrimaryKey = New DataColumn(0) {dtTipoCargo.Columns("TipoCargo")}

        Dim data As New SGDAC.DAC(Connection)
        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@TipoCobranza", TipoCobranza)
        Try
            data.LoadData(dtTipoCargo, "spCyCTipoCobranzaTipoCargo", CommandType.StoredProcedure, param, True)
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try
        Return dtTipoCargo
    End Function

    'Validación del consecutivo de cheque en la captura
    Public Function NumeroCuentaCliente(ByVal connection As SqlClient.SqlConnection, ByVal Cliente As Integer, _
        ByVal Banco As Short) As DataTable
        Dim _numeroCuentaCliente As New DataTable()
        Dim data As New SGDAC.DAC(connection)
        Dim param(1) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Cliente", Cliente)
        param(1) = New SqlClient.SqlParameter("@Banco", Banco)
        Try
            data.LoadData(_numeroCuentaCliente, "spCyCConsultaCuentaCliente", CommandType.StoredProcedure, param, True)
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try
        Return _numeroCuentaCliente
    End Function

    'Bitácora de registro de cobros
    Public Sub BitacoraCheque(ByVal connection As SqlClient.SqlConnection, ByVal AñoCobro As Short, _
            ByVal Cobro As Integer, ByVal Cliente As Integer, ByVal Observaciones As String, ByVal Usuario As String)
        Dim data As New SGDAC.DAC(connection)
        Dim param(4) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@AñoCobro", AñoCobro)
        param(1) = New SqlClient.SqlParameter("@Cobro", Cobro)
        param(2) = New SqlClient.SqlParameter("@Cliente", Cliente)
        param(3) = New SqlClient.SqlParameter("@Observaciones", Observaciones)
        param(4) = New SqlClient.SqlParameter("@Usuario", Usuario)
        Try
            data.ModifyData("spCyCBitacoraCobro", CommandType.StoredProcedure, param)
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try
    End Sub

    'Validación de notas de ingreso existentes
    Public Function ValidacionNotaIngresoExistente(ByVal Connection As SqlClient.SqlConnection, ByVal Clave As String) As Boolean
        Dim _validacion As Boolean

        Dim data As New SGDAC.DAC(Connection)
        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Clave", Clave)
        Try
            _validacion = Convert.ToBoolean(data.LoadScalarData("spCyCValidaNotaIngresoExistente", CommandType.StoredProcedure, param))
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try

        Return _validacion
    End Function

    'Notas de ingreso validadas
    Public Function ValidacionNotaIngresoValidada(ByVal Connection As SqlClient.SqlConnection, ByVal Clave As String) As Boolean
        Dim _validacion As Boolean

        Dim data As New SGDAC.DAC(Connection)
        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Clave", Clave)
        Try
            _validacion = Convert.ToBoolean(data.LoadScalarData("spCyCValidaNotaIngresoCorrecta", CommandType.StoredProcedure, param))
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try

        Return _validacion
    End Function

    'Validacion del tipo de movimiento caja con el tipo de cobro
    Public Function ValidacionTipoCobroTipoMovimientoCaja(ByVal Connection As SqlClient.SqlConnection, _
            ByVal TipoMovimientoCaja As Byte, ByVal TipoCobro As Byte) As Boolean
        Dim _validacion As Boolean

        Dim data As New SGDAC.DAC(Connection)
        Dim param(1) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@TipoMovimientoCaja", TipoMovimientoCaja)
        param(1) = New SqlClient.SqlParameter("@TipoCobro", TipoCobro)
        Try
            _validacion = Convert.ToBoolean(data.LoadScalarData("spCyCTipoMovimientoCajaTipoCobro", CommandType.StoredProcedure, param))
        Catch ex As Exception
            Throw ex
        Finally
            data.CloseConnection()
        End Try

        Return _validacion
    End Function

End Module

#Region "garbage"
'Public Sub Main()

'    Dim oSplash As New frmSplash()
'    oSplash.ShowDialog()

'    Try
'        FechaOperacion = SigaMetClasses.FechaServidor.Date
'    Catch ex As Exception
'        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End
'    End Try

'    Dim oLogin As New SigaMetClasses.Seguridad(4, Application.ProductVersion, "LightSteelBlue")
'    If oLogin.ShowDialog = DialogResult.OK Then

'        GLOBAL_IDUsuario = oLogin.UserID

'        'El objeto oSeguridad ya queda público y puede ser usado desde cualquier parte
'        oSeguridad = New SigaMetClasses.cSeguridad(GLOBAL_IDUsuario, 4)
'        If Not oSeguridad.TieneAcceso("Acceso") Then
'            If Not (oSeguridad.TieneAcceso("SysAdmin")) Then
'                MessageBox.Show("Usted no tiene permiso para usar este módulo.", "Módulo de CyC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
'                Exit Sub
'            End If
'        End If

'        GLOBAL_Database = oLogin.BaseDatos
'        GLOBAL_Servidor = oLogin.Servidor
'        GLOBAL_Password = oLogin.Password
'        GLOBAL_UsuarioNT = oLogin.UsuarioNT
'        GLOBAL_IDEmpleado = oLogin.Empleado
'        GLOBAL_EmpleadoNombre = oLogin.EmpleadoNombre
'        GLOBAL_UsuarioNombre = oLogin.UsuarioNombre
'        GLOBAL_CelulaUsuario = oLogin.Celula
'        GLOBAL_CelulaDescripcion = oLogin.CelulaDescripcion
'        GLOBAL_CajaUsuario = oLogin.Caja
'        GLOBAL_SeguridadNT = oLogin.SeguridadNT
'        ConString = oLogin.CadenaConexion

'        If GLOBAL_CajaUsuario = 0 Then
'            GLOBAL_CapturaPermitida = False
'        Else
'            GLOBAL_UsuarioCobranza = oLogin.Cobranza
'            GLOBAL_CapturaPermitida = True
'        End If

'        'Parámetros del módulo
'        Try
'            GLOBAL_DiasAjuste = CType(oLogin.Parametros("DiasAjuste"), Byte)
'            GLOBAL_VersionAutorizada = CType(oLogin.Parametros("VersionAutorizada"), String)
'            GLOBAL_MensajeVersion = CType(oLogin.Parametros("MensajeVersion"), String)
'            'GLOBAL_UsuarioAjuste = CType(oLogin.Parametros("UsuarioAjuste"), String)
'            GLOBAL_UsuarioCaptura = CType(oLogin.Parametros("UsuarioCaptura"), String)
'            'GLOBAL_UsuarioCancelacion = CType(oLogin.Parametros("UsuarioCancelacion"), String)
'            GLOBAL_RutaReportes = CType(oLogin.Parametros("RutaReportes"), String)
'            GLOBAL_MaxRegistrosConsulta = CType(oLogin.Parametros("MaxRegistrosConsulta"), Integer)
'            GLOBAL_TipoMovCajaVentaGas = CType(oLogin.Parametros("TipoMovCajaVentaGas"), Byte)
'            GLOBAL_TipoMovCajaCheqDev = CType(oLogin.Parametros("TipoMovCajaCheqDev"), Byte)
'            'GLOBAL_UsaServidorSecundarioRep = CType(oLogin.Parametros("UsaServidorSecundarioRep"), Boolean)
'            'GLOBAL_NombreBaseDatosReportes = CType(oLogin.Parametros("NombreBaseDatosReportes"), String)
'            'GLOBAL_NombreServidorReportes = CType(oLogin.Parametros("NombreServidorReportes"), String)
'            'TODO: Se agregó el 12/10/2004 para habilitar y validar la cobranza de administración de edificios
'            GLOBAL_AplicaAdmEdificios = CType(oLogin.Parametros("AplicaAdmEdificios"), Boolean)
'            'Se agregó el 12/10/2004 para validar cobranza de edificios administrados
'            If GLOBAL_AplicaAdmEdificios Then
'                GLOBAL_TipoMovimientoAdmEdificios = CType(oLogin.Parametros("TipoMovCajaAdmEdificios"), Byte)
'                GLOBAL_RamoAdmEdificios = CType(oLogin.Parametros("RamoAdmEdificios"), String)
'                'TODO: Poner como operación en perfil
'                GLOBAL_NoAbonarClientePadreEdificio = CType(oLogin.Parametros("NoAbonarAClientePadreEdif"), Boolean)
'            End If

'            GLOBAL_AplicaValidaciónNotaCredito = CType(oLogin.Parametros("ValidaAplicacionNotaCredi"), Boolean)

'            GLOBAL_CadenaConexionExport = "Data Source=" & CStr(oLogin.Parametros("NombreServidorReportes")) & ";Initial Catalog=" & _
'                    CStr(oLogin.Parametros("NombreBaseDatosReportes")) & ";Integrated Security=Yes;"

'            'Se agregó para el control de transferencias bancarias
'            GLOBAL_TransferenciaActiva = CType(oLogin.Parametros("TransferenciaActiva"), Boolean)
'            GLOBAL_TipoMovimientoTransferencia = CType(oLogin.Parametros("TipoMovTransferencia"), Short)
'            'Se agregó para el control de saldos a favor
'            GLOBAL_SaldoAFavorActivo = CType(oLogin.Parametros("SaldoAFavorActivo"), Boolean)
'            GLOBAL_AplicacionSaldoAFavor = CType(oLogin.Parametros("AplicacionSaldoAFavor"), Boolean)
'            GLOBAL_ValorMinimoSaldoAFavor = CType(oLogin.Parametros("SaldoAFavorMinimo"), Double)
'            GLOBAL_TipoMovimientoSaldoAFavor = CType(oLogin.Parametros("TipoMovimientoSaldoAFavor"), Short)
'            GLOBAL_MaxSaldosAFavorAplParcialPendiente = CType(oLogin.Parametros("MaximoSaldosAFavor"), Short)

'            GLOBAL_BusquedaPorValeCredito = CType(oLogin.Parametros("BusquedaValeCredito"), Boolean)

'            GLOBAL_PGREFImporteExacto = CType(oLogin.Parametros("PGREFImporteExacto"), Boolean)

'        Catch ArgEx As ArgumentException
'            MessageBox.Show("El sistema no puede leer la información del parámetro.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

'        Catch ex As Exception
'            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

'        End Try

'        'If GLOBAL_UsuarioCancelacion = GLOBAL_IDUsuario Then
'        '    GLOBAL_UsuarioPuedeCancelar = True
'        'End If

'        'If GLOBAL_VersionAutorizada <> Application.ProductVersion.ToString Then
'        '    MessageBox.Show(GLOBAL_MensajeVersion, "Módulo de CyC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
'        '    Exit Sub
'        'End If

'        'IMPLEMENTACIÓN DEL UpDATER (ACTUALIZACION AUTOMÁTICA) 14/09/2004
'        Dim cnSigamet As New SqlClient.SqlConnection(ConString)
'        Dim updateSys As New SIGAMETSecurity.Updater(4, Application.ProductVersion, Application.StartupPath, cnSigamet)
'        If updateSys.Desactualizado = True Then
'            'Necesita actualizarse
'            Application.Exit()
'            Exit Sub
'        End If

'        'Carga de la lista de bancos y cuentas bancarias
'        cargaListaBancos(cnSigamet)
'        CargaCatalogos(cnSigamet)
'        GLOBAL_connection = cnSigamet

'        cnSigamet.Dispose()

'        'Explicitly set apartment state to Single Thread Apartment (STA)
'        System.Threading.Thread.CurrentThread.ApartmentState = System.Threading.ApartmentState.STA
'        Dim eh As New CustomExceptionHandler()
'        AddHandler Application.ThreadException, AddressOf eh.OnThreadException
'        Application.Run(New frmPrincipal())

'    End If
'End Sub

#End Region


