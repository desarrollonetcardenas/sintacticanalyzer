/* Clase CAnalizadorLexico.cs
    Autor:   Cardenas Serrano Hector Pablo
    Fecha de creación: Miércoles, 24 de Octubre de 2007, 07:47:08 a.m.
    Ultima modificación: 
    Motivo: 
  Función: Contiene metodos que permiten realizar la labor de un analizador lexico
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Descripción breve de CAnalizadorLexico.
	/// </summary>
	public class CAnalizadorLexico
	{		
		#region Constructores
		
		public CAnalizadorLexico()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		#endregion

		#region Funciones Personalizadas
		/// <summary>
		/// Funcion que identifica a que tipo de componente lexico pertenece el 
		/// caracter leido de la cadena de entrada
		/// </summary>
		/// <param name="parRes">Siguiente caracter leido de la cadena de entrada</param>
		/// <returns>Retorna un tipo entero indicando el Id de la tabla al que pertenece
		/// el carcater leido</returns>
		public int tipoDeSimbolo ( char parRes )
		{
			char cCar = parRes;
			CBuscarConcordancia objCBuscarConcordancia = new CBuscarConcordancia ();
			
			if ( objCBuscarConcordancia.IsCaracterEspecial ( cCar ) == true )
			{ 
				if ( objCBuscarConcordancia.IsopAritmetico( cCar ) == true )
				{
					return 4;
				}
				else if ( objCBuscarConcordancia.IsopLogico( cCar ) == true )
				{
					return 5;
				}
				else if (objCBuscarConcordancia.IsopRelacional( cCar ) == true )
				{
					return 6;
				}
				else if ( objCBuscarConcordancia.IsopAsignacion( cCar ) == true )
				{
					return 7;
				}
				else if ( objCBuscarConcordancia.IsParentesisCircular ( cCar ) == true )
				{
					return 8;
				}
				else if ( objCBuscarConcordancia.IsParentesisCuadrado ( cCar ) == true )
				{
					return 9;
				}
				else if ( objCBuscarConcordancia.IsLlaves ( cCar ) == true )
				{
					return 10;
				}
			}
			else if (objCBuscarConcordancia.IsCaracterAlfabeto ( cCar ) == true )
			{
				return 2;
			}
			else if ( WindowsApplication1.CBuscarConcordancia.IsDigito ( cCar ) == true )
			{
				return 3;
			}
			else if ( cCar == '\n' )//Caracter Fin de linea
			{
				return 11;
			}
			else if ( cCar == '\x0')
			{
				return 12;//Caracter Fin de Archivo
			}
			return -1;//Simbolo no reconocido
		}
								
		/// <summary>
		/// Identifica cual es el patron de concordancia con el que encaja la cadena leida 
		/// de la cadena de entrada
		/// </summary>
		/// <param name="parCadena">Cadena de Entrada proporcionada por el usuario</param>
		/// <param name="iAf">Apuntador Fijo en la cadena de entrada</param>
		/// <param name="iAm">Apuntador Movil en la cadena de entrada</param>
		/// <param name="sRes">Variable de control entre funciones</param>
		/// <param name="sRes2">Variable de control entre funciones</param>
		/// <returns>True si encontro una concordancia, FALSE en caso contrario</returns>
		public bool buscarConcordancia ( string parCadena, ref int iAf, ref int iAm, out string sRes, out string sRes2 )
		{
			string sCadena     = parCadena;			
			string sLexema     = string.Empty;
			bool bConcordancia = false;
			sRes  = string.Empty;
			sRes2 = string.Empty;
			char cCar = sCadena[iAm];

			CBuscarConcordancia objCBuscarConcordancia = new CBuscarConcordancia ();
			CAnalizadorLexico objCAnalizadorLexico = new CAnalizadorLexico ();
			//Espacios
			if ( cCar == ' ')
			{
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
				bConcordancia = true;
			}//Identificadores,Palabras Reservadas
			else if ( objCBuscarConcordancia.IsEstadoTerminalPalabraReservada ( sCadena, cCar, ref iAm) == true )
			{				
				sLexema = CAnalizadorLexico.extraerLexema ( sCadena, ref iAf,ref iAm );
				if ( objCBuscarConcordancia.IsPalabraReservada ( sLexema ) == false )
				{
					//Verificar si el Identificador ya existe para no agregarlo
					if ( objCBuscarConcordancia.IsExistsIdentificador ( sLexema ) == true )
					{
						sRes = "Identificador";
					}//Identificador Nuevo
					else
					{						
						CCompoLex.iIdentificador.Add ( sLexema );
						sRes = "Identificador";
					}					
				}
				bConcordancia = true;				
			}
			else if ( objCBuscarConcordancia.IsNumero ( sCadena, cCar, ref iAm, out sRes))
			{
				switch ( sRes )
				{
					case "NumEntero":
						bConcordancia = true;
						//Agregar simbolo a la tabla
						sLexema = extraerLexema ( sCadena, ref iAf, ref iAm );
						CCompoLex.NumerosEnteros.Add ( sLexema );
						sRes  = "Numero";
						sRes2 = "Entero";
						break;
					case "NumReal":
						bConcordancia = true;
						//Agregar simbolo a la tabla
						sLexema = extraerLexema ( sCadena, ref iAf, ref iAm );
						CCompoLex.NumerosFlotantes.Add ( sLexema );
						sRes  = "Numero";
						sRes2 = "Real";
						break;
					case "NumExpCientifica":
						bConcordancia = true;
						//Agregar simbolo a la tabla
						sLexema = extraerLexema ( sCadena, ref iAf, ref iAm );
						CCompoLex.NumerosNotacionCientifica.Add ( sLexema );
						sRes  = "Numero";
						sRes2 = "NotacionCientifica";
						break;
					default:
						sRes  = "";
						sRes2 = "";
						break;
				}
			}
			//Operador Aritmetico
			else if ( objCBuscarConcordancia.IsEstadoTerminalOpAritmetico ( sCadena, cCar, ref iAf, ref iAm ) == true )											
			{
				bConcordancia = true;
			}//Operador Logico
			else if ( objCBuscarConcordancia.IsEstadoTerminalOpLogico ( sCadena,cCar, ref iAf, ref iAm) == true )
			{
				bConcordancia = true;
			}//Operador Relacional
			else if ( objCBuscarConcordancia.IsEstadoTerminalOpRelacional ( sCadena, cCar, ref iAf, ref iAm ) == true )
			{
				bConcordancia = true;
			}//Operador Asignacion
			else if ( objCBuscarConcordancia.IsopAsignacion ( cCar ) == true )
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}//Parentesis Circular
			else if ( objCBuscarConcordancia.IsParentesisCircular ( cCar ) == true )
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}//Parentesis Cuadrado
			else if ( objCBuscarConcordancia.IsParentesisCuadrado ( cCar ) == true )
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}//Llaves
			else if ( objCBuscarConcordancia.IsLlaves ( cCar ) == true )
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}//Algun otro caracter especial
			else if ( objCBuscarConcordancia.IsCaracterEspecial ( cCar ) )
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}//Fin de Linea
			else if ( cCar == '\n')
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}//Fin de Archivo
			else if ( cCar == '\x0')
			{
				bConcordancia = false;
				sRes = "EOF";
			}//Simbolo no reconocido
			else
			{
				bConcordancia = true;
				cCar = objCAnalizadorLexico.sgteCar ( sCadena, ref iAm );
			}
			return bConcordancia;
		}
		
		/// <summary>
		/// Regresa el proximo simbolo de la cadena de entrada y ajusta el apuntador movil
		/// </summary>
		/// <param name="parCadena">Cadena de entrada dada por el usuario</param>
		/// <param name="pariAf">Apuntador Fijo</param>
		/// <param name="pariAm">Apuntador Movil</param>
		/// <returns>Proximo caracter de la cadena de entrada</returns>
		public char sgteCar ( string parCadena, ref int iAm )
		{
			string sCadena = parCadena;			
			return sCadena [++iAm];
		}
		
		/// <summary>
		/// Extrae la subcadena de la cadena entrada
		/// </summary>
		/// <param name="parValor">Valor extraido de una funcion de diagrama de transicion 
		/// de estado</param>
		/// <param name="parAf">Apuntador Fijo<€/param>
		/// <param name="parAm">Apuntador Movil</param>
		/// <returns>Retorna el lexema de la cadena de extrada</returns>
		public static string extraerLexema (string parsCadenaEntrada, ref int iAf, ref int iAm )
		{
			string sLexema = parsCadenaEntrada;
			int iLongitud  = 0;

			iLongitud = (iAm)-iAf;
			sLexema = parsCadenaEntrada.Substring ( iAf, iLongitud );

			return sLexema;
		}

		/// <summary>
		/// Extrae un lexema de la cadena de entrada dado el Token correspondiente
		/// </summary>
		/// <param name="sToken"></param>
		/// <returns></returns>
		public static string extraerLexema ( string sToken )
		{
			int iIndiceTabla=0;
			int iPosicionTabla=0;
			CCompoLex objCCompoLex = new CCompoLex ();
			string sLexema = string.Empty;
			
			iIndiceTabla = int.Parse(sToken[1].ToString());
			iPosicionTabla = int.Parse(sToken[3].ToString());

			switch (iIndiceTabla)
			{
				case 1:
					sLexema = objCCompoLex.sPalReservadas[iPosicionTabla];
					break;
				case 2:
					sLexema = objCCompoLex.sOpAritmeticos[iPosicionTabla];
					break;
				case 3:
					sLexema = objCCompoLex.sOpRelacionales[iPosicionTabla];
					break;
				case 4:
					sLexema = objCCompoLex.sOpLogicos[iPosicionTabla];
					break;
				case 5:
					sLexema = objCCompoLex.sParCircular[iPosicionTabla];
					break;
				case 6:
					sLexema = objCCompoLex.sParCuadrado[iPosicionTabla];
					break;
				case 7:
					sLexema = objCCompoLex.sLlaves[iPosicionTabla];
					break;
				case 8:
					sLexema = CCompoLex.iIdentificador[iPosicionTabla].ToString();
					break;
				case 9:
					sLexema = CCompoLex.NumerosEnteros[iPosicionTabla].ToString();
					break;
				case 10:
					sLexema = CCompoLex.NumerosFlotantes[iPosicionTabla].ToString();
					break;
				case 11:
					sLexema = CCompoLex.NumerosNotacionCientifica[iPosicionTabla].ToString();
					break;
			}

			return sLexema;
	
		}

		/// <summary>
		/// Token Lexema General
		/// </summary>
		/// <param name="parsCadEntrada">Cadena de entrada dada por el usuario</param>
		/// <param name="parsLexema">Lexema extraido de la cadena de entrada</param>
		/// <param name="iAf">Apuntador Fijo</param>
		/// <param name="iAm">Apuntador Movil</param>
		/// <returns></returns>
		public string tokenLexema ( string parsCadEntrada, string parsLexema, ref int iAf, ref int iAm )
		{
			string sLexema = parsLexema;
			string sToken = string.Empty;
			string sCadEntrada = parsCadEntrada;
			char cCar = sLexema[0];
			int i = 0;
			CCompoLex objCCompoLex = new CCompoLex ();
			CBuscarConcordancia objCBuscarConcordancia = new CBuscarConcordancia ();			
			
						
			for ( ; i<=objCCompoLex.sPalReservadas.Length-1; i++ )
			{
				if ( sLexema.Equals(objCCompoLex.sPalReservadas[i]))
					return "(1," + i.ToString() + ")";
				else
					continue;
			}			

			for ( i=0; i<=objCCompoLex.sOpAritmeticos.Length-1; i++)
			{
				if ( sLexema.Equals(objCCompoLex.sOpAritmeticos[i]))
					return "(2," + i.ToString() + ")";
				else
					continue;
			}

			for ( i=0; i<=objCCompoLex.sOpRelacionales.Length-1; i++)
			{
				if (sLexema.Equals (objCCompoLex.sOpRelacionales[i]))
					return "(3," + i.ToString() + ")";
				else
					continue;
			}

			for ( i=0; i<=objCCompoLex.sOpLogicos.Length-1; i++)
			{
				if (sLexema.Equals(objCCompoLex.sOpLogicos[i]))
					return "(4," + i.ToString() + ")";
			}

			for ( i=0; i<=objCCompoLex.sParCircular.Length-1; i++)
			{
				if (sLexema.Equals(objCCompoLex.sParCircular[i]))
					return "(5," + i.ToString() + ")";
			}

			for ( i=0; i<=objCCompoLex.sParCuadrado.Length-1; i++)
			{
				if (sLexema.Equals(objCCompoLex.sParCuadrado[i]))
					return "(6," + i.ToString() + ")";
			}

			for ( i=0; i<=objCCompoLex.sLlaves.Length-1; i++)
			{
				if (sLexema.Equals(objCCompoLex.sLlaves[i]))
					return "(7," + i.ToString() + ")";
			}			

			if ( sLexema.Equals("="))
			{
				return "(12,1)";
			}
			else
			{
				return "";
			}
			
		}

		/// <summary>
		/// Token Lexema para Numeros
		/// </summary>
		/// <param name="parsLexema"></param>
		/// <param name="parRes">Variable de control de flujo</param>
		/// <param name="sparRes2">Variable de control de flujo</param>
		/// <param name="Numeros">Variable para identificar a la funcion "Numeros"</param>
		/// <returns>El Token la cadena de entrada</returns>
		public string tokenLexema ( string parsLexema, string parRes, string sparRes2, string Numeros )
		{
			string sToken = string.Empty;
			string sRes   = parRes;
			string sRes2  = sparRes2;
			string sLexema= parsLexema;
			string sNumeros = Numeros;//Etiqueta para identificar que es un token de Numero
			//Casos para determinar token para los numeros
			switch (sRes2)
			{
				case "Entero":
					sToken = "(9," + sLexema.ToString () + ")";
					break;
				case "Real":
					sToken = "(10," + sLexema.ToString () + ")";
					break;
				case "NotacionCientifica":
					sToken = "(11," + sLexema.ToString () + ")";
					break;
				default:
					sToken = "";
					break;
			}
			return sToken;
		}

		/// <summary>
		/// Token Lexema para Identificadores
		/// </summary>
		/// <param name="parsLexema">Lexema de la cadena de entrada</param>
		/// <param name="Identificador">Variable para identificar la funcion "Identificador"</param>
		/// <returns>El Token la cadena de entrada</returns>
		public string tokenLexema  ( string parsLexema, string Identificador  )
		{
			string sToken  = string.Empty;			
			string sLexema = parsLexema;			
			int i = 0;

			//Verificar Identificador y regresar su token
			for ( ;i<=CCompoLex.iIdentificador.Count; i++ )
			{
				if ( sLexema.Equals (CCompoLex.iIdentificador[i].ToString ()) )
				{				
					sToken = "(8," + i.ToString () + ")";
					break;
				}
				else
				{
					continue;
				}
			}//Fin for									

			return sToken;
		}
		/// <summary>
		/// Permite reestablecer el valor contenido por el apuntador Movil una posicion hacia atras
		/// </summary>
		/// <param name="cCar">Caracter leido actualmente</param>
		/// <param name="sCadEntrada">Cadena de Entrada dada por el usuario</param>
		/// <param name="iAf">Apuntador Fijo</param>
		/// <param name="iAm">Apuntador Movil</param>
		public static void retrocedeApuntador ( ref char cCar, string sCadEntrada, ref int iAm )
		{			
			iAm = iAm - 1;
			cCar = sCadEntrada[iAm];
		}

		/// <summary>
		/// Permite reestablecer el valor contenido por el apuntador Movil N posiciones hacia atras
		/// </summary>
		/// <param name="cCar">Caracter de la cadena de Entrada</param>
		/// <param name="sCadEntrada">Cadena de Entrada</param>
		/// <param name="iAm">Apuntador Movil</param>
		/// <param name="parValorRetroceso">Numero de pocisiones a retroceder</param>
		public static void retrocedeApuntador ( ref char cCar, string sCadEntrada, ref int iAm, int parValorRetroceso )
		{			
			int iRetroceso = parValorRetroceso;
			iAm = iRetroceso;
			cCar = sCadEntrada[iAm];
		}

		/// <summary>
		/// Regresa el Token de la Expresion reconocida de la cadena de entrada
		/// </summary>
		/// <param name="parsCadEntrada"></param>
		/// <param name="iAf"></param>
		/// <param name="iAm"></param>
		/// <returns></returns>
		public string analizadorLexico ( string parsCadEntrada, ref int iAf, ref int iAm )
		{			
			bool bConcordancia = false;			
			string sCadEntrada = parsCadEntrada;
			string sLexema = string.Empty;
			string sToken  = string.Empty;
			string sRes    = string.Empty;			
			string sRes2   = string.Empty;

			bConcordancia = buscarConcordancia( sCadEntrada + "\x0", ref iAf, ref iAm, out sRes, out sRes2 );
			
			if (bConcordancia)
			{
				sLexema = string.Empty;
				sLexema = extraerLexema ( sCadEntrada, ref iAf, ref iAm);
				
				switch ( sRes )
				{
						//Token Lexema Numeros
					case "Numero":								
						sToken = tokenLexema ( sLexema, sRes, sRes2, "Numeros" );
						break;
						//Token Lexema Identificador
					case "Identificador":
						sToken = tokenLexema ( sLexema, "Identificador");
						break;
					default:
						sToken = "";
						break;
				}
																
				if ( sToken == string.Empty )
				{
					sToken = tokenLexema ( sCadEntrada, sLexema, ref iAf, ref iAm );							
				}
				else
				{
					
				}
				iAf = iAm;//Igualar la posicion de los dos apuntadores
			}//Simbolo no reconocido
			else
			{
				sToken = "EOF";
			}
			return sToken;
		}

		/// <summary>
		/// Agrega el Token junto con su correspondiente Lexema al Control ListView
		/// </summary>
		/// <param name="parLstVw">Control a agregar la informacion</param>
		/// <param name="parsLexema">Lexema a agregar</param>
		/// <param name="parsToken">Token del Lexema a agregar</param>
		private void mostrarTokenLexema ( System.Windows.Forms.ListView parLstVw, string  parsLexema, string parsToken )
		{
			string sLexema = parsLexema;
			string sToken  = parsToken;
			int iLen = 0;
			System.Windows.Forms.ListView lstInfo = parLstVw;
			iLen = lstInfo.Items.Count;

			if ( sLexema != " " && sLexema != "\n" && sLexema != "\t" && sLexema != "\r")
			{
				lstInfo.Items.Add(sLexema.ToString());
				lstInfo.Items[iLen].SubItems.Add(sToken.ToString());
			}
				//Token Fin de Archivo
			else if ( sLexema == "Fin Archivo" )
			{
				lstInfo.Items.Add(sLexema.ToString());
				lstInfo.Items[iLen].SubItems.Add("EOF");
			}
		}


		#endregion				
	}
}
