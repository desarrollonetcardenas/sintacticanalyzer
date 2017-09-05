/* Clase CBuscarConcordancia.cs
    Autor:   Cardenas Serrano Hector Pablo
    Fecha de creación: Domingo, 28 de Octubre de 2007, 08:55:50 p.m
    Ultima modificación: 
    Motivo: 
  Función: Contiene metodos que permiten realizar la tarea del analizador lexico en conjunto con la
  clase 'CAnalizadorLexico.cs'  
 */
using System;

namespace WindowsApplication1
{
	/// <summary>
	/// Descripción breve de CBuscarConcordancia.
	/// </summary>
	public class CBuscarConcordancia
	{
		#region Variables de la clase				
			CCompoLex objCCompoLex;
		#endregion
		
		#region Funciones personalizadas
		/// <summary>
		/// Permite identificar si el caracter leido pertenece a la tabla del CDigitos
		/// </summary>
		/// <param name="parCar">Caracter leido desde la cadena de entrada</param>
		/// <returns>True Si encontro digito False si no lo encontro</returns>
		public static bool IsDigito ( char parCar )
		{
			CCompoLex objCCompoLex = new CCompoLex ();
			int i     = 0;
			char cCar = parCar;
			

			for (; i < objCCompoLex.iDigitos.Length; i++ )
			{
				if ( cCar == objCCompoLex.iDigitos[i] )
				{					
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Ejecuta el diagrama de transicion correspondiente para identificar
		/// Operadores Aritmeticos
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="parAf">Apuntador Fijo</param>
		/// <param name="parAm">Apuntador Movil</param>
		/// <returns>True su encutra una concordancia, False en caso contrario</returns>
		public bool IsEstadoTerminalOpAritmetico ( string parCadEntrada, char parCar, ref int iAf, ref int iAm )
		{
			char cCar = parCar;
			string sCadEntrada = parCadEntrada;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 1;
			bool bError  = false;
			bool bEstadoFinal = false;
			
			while ( !bEstadoFinal )
			{
				switch ( iEstado )
				{
					case 1:
						if ( cCar == '*' || cCar == '/')
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '+' )
						{
							iEstado = 5;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '-' )
						{
							iEstado = 7;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 2:
						if (cCar == '=')
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 3;						
						}						
						break;
					case 3:
						bEstadoFinal = true;
						break;
					case 4:
						bEstadoFinal = true;
						break;
					case 5:
						if ( cCar == '=' )
						{
							iEstado = 11;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '+' )
						{
							iEstado = 6;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 10;
						}						
						break;
					case 6:
						bEstadoFinal = true;
						break;
					case 7:
						if ( cCar == '-' ) 
						{
							iEstado = 8;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '=')						
						{
							iEstado = 12;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 9;
						}						
						break;
					case 8:
						bEstadoFinal = true;
						break;
					case 9:
						bEstadoFinal = true;
						break;
					case 10:
						bEstadoFinal = true;
						break;
					case 11:
						bEstadoFinal = true;
						break;
					case 12:
						bEstadoFinal = true;
						break;
					default:
						break;				
				}//switch
			}//Fin while
			
			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}

		/// <summary>
		/// Ejecuta el diagrama de transicion correspondiente para identificar
		/// Operadores Logicos
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="parAf">Apuntador Fijo</param>
		/// <param name="parAm">Apuntador Movil</param>
		/// <returns>True si encutra un estado terminal, False en caso contrario</returns>
		public bool IsEstadoTerminalOpLogico ( string parCadEntrada, char parCar, ref int iAf, ref int iAm )
		{
			char cCar = parCar;			
			string sCadEntrada = parCadEntrada;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 0;
			bool bError  = false;
			bool bEstadoFinal = false;

			while ( !bEstadoFinal )
			{				
				switch ( iEstado )
				{
					case 0:
						if ( cCar == '&')
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );

						}
						else if ( cCar == '|' )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '!' )
						{
							iEstado = 3;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 1:
						if ( cCar == '&' )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 4;
						}
						break;					
					case 2:
						if ( cCar == '|' )
						{
							iEstado = 5;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 5;
						}
						break;
					case 3:
						bEstadoFinal = true;
						break;
					case 4:
						bEstadoFinal = true;
						break;
					case 5:
						bEstadoFinal = true;
						break;					
					default:
						break;
				}
			}//Fin while
			
			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}

		/// <summary>
		/// Metodo que implemente el diagrama de trancision de estados para
		/// identificar Operadores Relacionales
		/// </summary>
		/// <param name="parCar">Caracter de entrada al diagrama</param>
		/// <param name="Af">Apuntador Fijo</param>
		/// <param name="Am">Apuntador Movil</param>
		///<returns>True si encutra un estado terminal, False en caso contrario</returns> 
		public bool IsEstadoTerminalOpRelacional ( string parCadEntrada, char parCar, ref int iAf, ref int iAm )
		{
			char cCar = parCar;
			string sCadEntrada = parCadEntrada;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 0;
			bool bError  = false;
			bool bEstadoFinal = false;

			while ( !bEstadoFinal )
			{
				switch ( iEstado )
				{
					case 0:
						if ( cCar == '>' || cCar == '<')
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '=' )
						{
							iEstado = 5;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '!' )
						{
							iEstado = 3;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 1:
						if ( cCar == '=' )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 7;
						}
						break;
					case 2:
						bEstadoFinal = true;
						break;
					case 3:
						if ( cCar == '=' )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
							CAnalizadorLexico.retrocedeApuntador ( ref cCar, sCadEntrada, ref iAm );
						}
						break;
					case 4:
						bEstadoFinal = true;
						break;
					case 5:
						if ( cCar == '=' )
						{
							iEstado = 6;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
							CAnalizadorLexico.retrocedeApuntador ( ref cCar, sCadEntrada, ref iAm );
						}
						break;
					case 6:
						bEstadoFinal = true;
						break;
					case 7:
						bEstadoFinal = true;
						break;
					default:
						break;
				}
			}//Fin while
			
			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}

		/// <summary>
		/// Ejecuta el diagrama de transicion correspondiente para identificar
		/// Palabras Reservadas o Identificadores
		/// </summary>
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="parAf">Apuntador Fijo</param>
		/// <param name="parAm">Apuntador Movil</param>
		/// <returns>True si encuetra una concordancia, False en caso contrario</returns>
		public bool IsEstadoTerminalPalabraReservada ( string parCadEntrada, char parCar, ref int iAm )
		{		
			char cCar = parCar;			
			string sCadEntrada = parCadEntrada;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 0;
			bool bError  = false;
			bool bEstadoFinal = false;
			CBuscarConcordancia objCBuscarConcordancia = new CBuscarConcordancia ();			

			while ( !bEstadoFinal )
			{
				switch ( iEstado )
				{
					case 0:
						if ( objCBuscarConcordancia.IsCaracterMin ( cCar ) == true )
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( objCBuscarConcordancia.IsCaracterMay ( cCar ) == true )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 1:
						if ( objCBuscarConcordancia.IsCaracterMin ( cCar ) == true )
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( IsDigito ( cCar ) == true )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( objCBuscarConcordancia.IsCaracterMay ( cCar ) == true )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 4;
						}
						break;
					case 2:
						if ( IsDigito ( cCar ) == true )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( objCBuscarConcordancia.IsCaracterMin ( cCar ) == true )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( objCBuscarConcordancia.IsCaracterMay ( cCar ) == true ) 
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 3;
						}
						break;
					case 3:
						bEstadoFinal = true;
						break;
					case 4:
						bEstadoFinal = true;
						break;					
					default:
						break;
				}
			}//Fin while
			
			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}
				
		/// <summary>
		/// Ejecuta el diagrama de transicion correspondiente para identificar
		/// Numeros Enteros, Numeros Reales o Exp. Cientifica
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="parAf">Apuntador Fijo</param>
		/// <param name="parAm">Apuntador Movil</param>
		/// <returns>True si encutra un estado terminal, False en caso contrario</returns>
		public bool IsNumero ( string parCadEntrada, char parCar, ref int iAm, out string sRes )
		{
			char cCar = parCar;			
			string sCadEntrada = parCadEntrada;
			sRes = string.Empty;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 0;
			bool bError  = false;
			bool bEstadoFinal = false;
			

			while ( !bEstadoFinal )
			{				
				switch ( iEstado )
				{
					case 0:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 1:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '.' ) 
						{
							iEstado = 3;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 2;
						}
						break;
					case 2:
						bEstadoFinal = true;
						sRes = "NumEntero";
						break;
					case 3:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 4:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == 'e' || cCar == 'E')
						{
							iEstado = 6;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 5;
						}
						break;
					case 5:		
						bEstadoFinal = true;
						sRes = "NumReal";
						break;
					case 6:
						if ( cCar == '+' || cCar == '-' )
						{
							iEstado = 7;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( IsDigito ( cCar ) == true )
						{
							iEstado = 8;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 7:
						if ( IsDigito ( cCar ) == true )
						{
							iEstado = 8;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 8:
						if ( IsDigito ( cCar ) == true ) 
						{
							iEstado = 8;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 9;
						}
						break;
					case 9:
						bEstadoFinal = true;
						sRes = "NumExpCientifica";
						break;					
					default:
						break;
				}
			}//Fin while
			
			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}
				
		/// <summary>
		/// Ejecuta el diagrama de transicion de estados para reconocer solamente
		/// Numeros Enteros
		/// </summary>
		/// <param name="parCadEntrada">Cadena de entrada dada por el usuario</param>
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="iAf">Apuntador Fijo</param>
		/// <param name="iAm">Apuntador Movil</param>
		/// <returns>TRUE si logra una concordancia, FALSE en caso contrario</returns>
		public bool IsNumEntero ( string parCadEntrada, char parCar, ref int iAf, ref int iAm )
		{
			char cCar = parCar;			
			string sCadEntrada = parCadEntrada;			
			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 0;
			bool bError  = false;
			bool bEstadoFinal = false;
			

			while ( !bEstadoFinal )
			{
				switch ( iEstado )
				{
					case 0:
						if  ( IsDigito ( cCar ) == true ) 
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 1:
						if  ( IsDigito ( cCar ) == true ) 
						{
							iEstado = 1;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == '.' )
						{
							iEstado = 3;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							iEstado = 2;
						}
						break;
					case 2:
						bEstadoFinal = true;
						break;
					case 3:
						bEstadoFinal = true;
						bError = true;
						break;
				}
			}

			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}
				
		/// <summary>
		/// Ejecuta el diagrama de transicion de estados para reconocer solamente
		/// Numeros Reales
		/// </summary>
		/// <param name="parCadEntrada">Cadena de entrada dada por el usuario</param>
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="iAf">Apuntador Fijo</param>
		/// <param name="iAm">Apuntador Movil</param>
		/// <returns>TRUE si logra una concordancia, FALSE en caso contrario</returns>
		public bool IsNumReal( string parCadEntrada, char parCar, ref int iAf, ref int iAm )
		{
			char cCar = parCar;		
			string sCadEntrada = parCadEntrada;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 1;
			bool bError  = false;
			bool bEstadoFinal = false;			

			while ( !bEstadoFinal )
			{
				switch ( iEstado )
				{
					case 1:
						if  ( cCar == '.' )
						{
							iEstado = 3;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 3:
						if  ( IsDigito ( cCar ) == true ) 
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 4:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == 'e' || cCar == 'E') 
						{
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
							bEstadoFinal = true;
							bError = true;
						}
						else
						{
							iEstado = 5;
						}
						break;
					case 5:
						bEstadoFinal = true;
						break;
					default:
						break;
				}
			}

			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}

		/// <summary>
		///  Ejecuta el diagrama de transicion de estados para reconocer solamente
		/// Numeros Notacion Cientifica Normalizada
		/// </summary>
		/// <param name="parCadEntrada">Cadena de entrada dada por el usuario</param>
		/// <param name="parCar">Caracter de entrada al diagrama de transicion</param>
		/// <param name="iAm">Apuntador Movil</param>
		/// <returns>TRUE si logra una concordancia, FALSE en caso contrario</returns>
		public bool IsNumNotacionCientificaNormalizada( string parCadEntrada, char parCar, ref int iAm )
		{
			char cCar = parCar;
			string sCadEntrada = parCadEntrada;

			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();

			int iEstado  = 1;
			bool bError  = false;
			bool bEstadoFinal = false;			

			while ( !bEstadoFinal )
			{
				switch ( iEstado )
				{
					case 1:
						if  ( cCar == '0' )
						{
							iEstado = 2;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}						
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 2:
						if  ( cCar == '.' )
						{
							iEstado = 3;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else 
						{
							bError = true;
							bEstadoFinal = true;	
						}
						break;
					case 3:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 4:
						if  ( IsDigito ( cCar ) == true )
						{
							iEstado = 4;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( cCar == 'e' || cCar == 'E' )
						{
							iEstado = 6;
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 6:
						if ( cCar == '+' || cCar == '-' )
						{
							iEstado = 7;
							cCar = objAnalizadorLexico.sgteCar ( sCadEntrada, ref iAm );
						}
						else if ( IsDigito ( cCar ) == true )
						{
							iEstado = 8;
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 7:
						if ( IsDigito ( cCar ) == true )
						{
							iEstado = 8;
						}
						else
						{
							bError = true;
							bEstadoFinal = true;
						}
						break;
					case 8:
						if ( IsDigito ( cCar ) == true )
						{
							iEstado = 8;
						}
						else
						{
							iEstado = 9;
						}
						break;
					case 9:
						bEstadoFinal = true;
						break;
					default:
						break;
				}
			}//Fin while
			
			if ( bError == false ) 
			{
				return true;
			}
			else
			{						
				return false;
			}
		}
		
		/// <summary>
		/// Determina si el Lexema mandado como parametro pertenece a la tabla de "Palabras Reservadas"
		/// </summary>
		/// <param name="parsLexema">Lexema a identificar</param>
		/// <returns>TRUE cuando pertenece, en caso contrario FALSE</returns>
		public bool IsPalabraReservada ( string parsLexema )
		{
			CCompoLex objCCompoLex = new CCompoLex ();
			string sLexema         = parsLexema;
			int i = 0;

			for (; i < objCCompoLex.sPalReservadas.Length; i++ )
			{
				if ( sLexema.Equals (objCCompoLex.sPalReservadas[i]) )
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="parsLexema"></param>
		/// <returns></returns>
		public bool IsExistsIdentificador ( string parsLexema )
		{
			string sLexema = parsLexema;
			bool bExists = false;

			for ( int i=0; i<CCompoLex.iIdentificador.Count; i++)
			{
				if ( sLexema.Equals (CCompoLex.iIdentificador[i].ToString () ))
				{
					bExists = true;
					break;
				}
				else
				{
					continue;
				}
			}
			return bExists;
		}		
		/// <summary>
		/// Permite identificar si el caracter leido pertenece a la tabla del Alfabeto
		/// </summary>
		/// <param name="parCar">Caracter leido de la cadena de entrada</param>
		/// <returns>Retorna un valor bool indicando si el caracter pertenece a 'Alfabeto'</returns>
		public bool IsCaracterAlfabeto ( char parCar )
		{
			int i     = 0;			
			char cCar = parCar;

			for (; i < objCCompoLex.cAlfabeto.Length; i++ )
			{
				if ( cCar == objCCompoLex.cAlfabeto[i] )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Permite identificar si el caracter leido pertenece el alfabeto en Minuscula
		/// </summary>
		/// <param name="parCar">Caracter leido de la cadena de entrada</param>
		/// <returns>Retorna un valor bool indicando si el caracter pertenece al Alfabeto en Minuscula</returns>
		public bool IsCaracterMin ( char parCar )
		{
			int i     = 0;
			char cCar = parCar;

			for (; i < objCCompoLex.cCarMin.Length; i++ )
			{
				if ( cCar == objCCompoLex.cCarMin[i] )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Permite identificar si el caracter leido pertenece el alfabeto en Mayuscula
		/// </summary>
		/// <param name="parCar">Caracter leido de la cadena de entrada</param>
		/// <returns>Retorna un valor bool indicando si el caracter pertenece al Alfabeto en Mayuscula</returns>
		public bool IsCaracterMay ( char parCar )
		{
			int i     = 0;
			char cCar = parCar;

			for (; i < objCCompoLex.cCarMay.Length; i++ )
			{
				if ( cCar == objCCompoLex.cCarMay[i] )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Permite identificar si el caracter leido pertenece a la tabla CCarEspecial
		/// </summary>
		/// <param name="parCar">Caracter leido de la cadena de entrada</param>
		/// <returns>Retorna un valor int indicando el ID de la tabla a donde corresponde el caracter identificado</returns>
		public bool IsCaracterEspecial ( char parCar )
		{
			char cCar = parCar;
			int i     = 0;			

			for (; i < objCCompoLex.cCarEspecial.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecial[i] == cCar)
				{
					return true;
				}
			}
			return false;
		}


		public bool IsopRelacional ( char parCar )
		{
			char cCar = parCar;
			int i = 0;

			for (; i < objCCompoLex.cCarEspecialOpRelacionales.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecialOpRelacionales[i] == cCar )
				{
					return true;
				}
			}
			return false;
		}


		public bool IsopLogico ( char parCar )
		{
			char cCar = parCar;			
			int i = 0;

			for (; i < objCCompoLex.cCarEspecialOpLogicos.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecialOpLogicos[i] == cCar )
				{
					return true;
				}
			}
			return false;
		}


		public bool IsopAritmetico ( char parCar )
		{
			char cCar = parCar;					
			int i = 0;

			for (; i < objCCompoLex.cCarEspecialOpAritmeticos.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecialOpAritmeticos[i] == cCar )
				{
					return true;
				}
			}
			return false;
		}


		public bool IsopAsignacion ( char parCar )
		{
			char cCar = parCar;
						
			if ( cCar == objCCompoLex.cCarEspecialOpAsignacion  )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool IsParentesisCircular ( char parCar )
		{
			char cCar = parCar;			
			int i = 0;

			for (; i < objCCompoLex.cCarEspecialParCircular.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecialParCircular[i] == cCar )
				{
					return true;
				}
			}
			return false;
		}

		public bool IsParentesisCuadrado ( char parCar )
		{
			char cCar = parCar;			
			int i = 0;

			for (; i < objCCompoLex.cCarEspecialParCuadrado.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecialParCuadrado[i] == cCar )
				{
					return true;
				}
			}
			return false;
		}

		public bool IsLlaves ( char parCar )
		{
			char cCar = parCar;			
			int i = 0;

			for (; i < objCCompoLex.cCarEspecialLlaves.Length; i++ )
			{
				if ( objCCompoLex.cCarEspecialLlaves[i] == cCar )
				{
					return true;
				}
			}
			return false;
		}


		#endregion
		
		#region Constructores
		
		public CBuscarConcordancia()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
			objCCompoLex = new CCompoLex ();
		}


		#endregion
	}
}
