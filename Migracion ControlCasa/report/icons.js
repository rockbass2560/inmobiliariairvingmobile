function getIcon(objectType,messageType)
{

    switch (objectType)
    {
		case "packaged-procedure":
        case "procedure":
        {
            switch (messageType)
            {
                case "error":
                    return icon.procedure_error;
                case "warning":
                    return icon.procedure_warning;
                case "info":
                    return icon.procedure_info;
                default:
                    return icon.procedure;
            }
        }
         case "schema":
        {
            switch (messageType)
            {
                case "error":
                    return icon.schema_error;
                case "warning":
                    return icon.schema_warning;
                case "info":
                    return icon.schema_info;
                default:
                    return icon.schema;
            }
        }
        case "table":
        {
            switch (messageType)
            {
                case "error":
                    return icon.table_error;
                case "warning":
                    return icon.table_warning;
                case "info":
                    return icon.table_info;
                default:
                    return icon.table;
            }
        }
        case "view":
        {
            switch (messageType)
            {
                case "error":
                    return icon.view_error;
                case "warning":
                    return icon.view_warning;
                case "info":
                    return icon.view_info;
                default:
                    return icon.view;
            }
        }
        case "trigger":
        {
            switch (messageType)
            {
                case "error":
                    return icon.trigger_error;
                case "warning":
                    return icon.trigger_warning;
                case "info":
                    return icon.trigger_info;
                default:
                    return icon.trigger;
            }
        }
        
        case "index":
        {
            switch (messageType)
            {
                case "error":
                    return icon.index_error;
                case "warning":
                    return icon.index_warning;
                case "info":
                    return icon.index_info;
                default:
                    return icon.index;
            }
        }

        case "database":
        {
            switch (messageType)
            {
                case "error":
                    return icon.database_error;
                case "warning":
                    return icon.database_warning;
                case "info":
                    return icon.database_info;
                default:
                    return icon.database;
            }
        }  
		case "private-packaged-function":
        {
            switch (messageType)
            {
                case "error":
                    return icon.private_function_error;
                case "warning":
                    return icon.private_function_warning;
                case "info":
                    return icon.private_function_info;
                default:
                    return icon.private_function_gif;
            }
        }
		
		case "private-packaged-procedure":
        {
            switch (messageType)
            {
                case "error":
                    return icon.private_procedure_error;
                case "warning":
                    return icon.private_procedure_warning;
                case "info":
                    return icon.private_procedure_info;
                default:
                    return icon.private_procedure_gif;
            }
        }
		case "packaged-function":
	    case "function":
	    {   
                switch (messageType)
                {
                    case "error":
                        return icon.function_error;
                    case "warning":
                        return icon.function_warning;
                    case "info":
                        return icon.function_info;
                    default:
                        return icon.function_gif;
                }
        }
		
		case "private-packaged-subtype":
		case "private-packaged-type":
		{
			switch (messageType)
            {
                case "error":
                    return icon.private_type_error;
                case "warning":
                    return icon.private_type_warning;
                case "info":
                    return icon.private_type_info;
                default:
                    return icon.private_type_gif;
            }
		}

	    case "packaged-type":
		case "packaged-subtype":
		{
			switch (messageType)
            {
                case "error":
                    return icon.type_error;
                case "warning":
                    return icon.type_warning;
                case "info":
                    return icon.type_info;
                default:
                    return icon.type_gif;
            }
		}
		case "statement":
		{
			switch (messageType)
            {
                case "error":
                    return icon.statement_error;
                case "warning":
                    return icon.statement_warning;
                case "info":
                    return icon.statement_info;
                default:
                    return icon.statement_gif;
            }
		}
		case "user-defined-type":
		{
			switch (messageType)
            {
                case "error":
                    return icon.datatype_error;
                case "warning":
                    return icon.datatype_warning;
                case "info":
                    return icon.datatype_info;
                default:
                    return icon.datatype_gif;
            }
		}
		case "package":
		{
			switch (messageType)
            {
                case "error":
                    return icon.package_error;
                case "warning":
                    return icon.package_warning;
                case "info":
                    return icon.package_info;
                default:
                    return icon.package_gif;
            }
		}
		case "synonym":
		{
		    switch (messageType)
            {
                case "error":
                    return icon.synonym_error;
                case "warning":
                    return icon.synonym_warning;
                case "info":
                    return icon.synonym_info;
                default:
                    return icon.synonym_gif;
            }
        }
        case "sequence":
		{
		    switch (messageType)
            {
                case "error":
                    return icon.sequence_error;
                case "warning":
                    return icon.sequence_warning;
                case "info":
                    return icon.sequence_info;
                default:
                    return icon.sequence_gif;
            }
        }
    }
}    


icon = {

		source              : 'img/root_node.gif',
		
		folder			    : 'img/folder.gif',
		
		folder_warning      : 'img/folder_warning.gif',
		
		folder_error        : 'img/folder_error.gif',
		
		folder_info         : 'img/folder_info.gif',

		folderOpen	: 'img/folderopen.gif',

		table               : 'img/table.gif',
		
		table_warning       : 'img/table_warning.gif',
		
		table_error       : 'img/table_error.gif',
		
		table_info       : 'img/table_info.gif',
		
		index               : 'img/index.gif',
		
		index_warning       : 'img/index_warning.gif',
		
		index_error       : 'img/index_error.gif',
		
		index_info       : 'img/index_info.gif',
		
		trigger             : 'img/trigger.gif',
		
		trigger_warning     : 'img/trigger_warning.gif',
		
		trigger_error     : 'img/trigger_error.gif',
		
		trigger_info     : 'img/trigger_info.gif',
		
		view                : 'img/view.gif',
		
		view_warning        : 'img/view_warning.gif',
		
		view_error        : 'img/view_error.gif',
		
		view_info        : 'img/view_info.gif',
		
		procedure           : 'img/procedure.gif',
		
		procedure_warning   : 'img/procedure_warning.gif',
		
		procedure_error   : 'img/procedure_error.gif',
		
		procedure_info   : 'img/procedure_info.gif',
		
		schema   : 'img/schema.gif',
		
		schema_error      : 'img/schema_error.gif',
		
		database   : 'img/database.gif',
		
		database_error      : 'img/database_error.gif',
		
		database_info		: 'img/database_info.gif',
		
		database_warning		: 'img/database_warning.gif',
		
		empty				: 'img/empty.gif',

		nlPlus			: 'img/nolines_plus.gif',

		nlMinus			: 'img/nolines_minus.gif',
		
		function_gif		: 'img/function.gif',
		
		function_error		: 'img/function_error.gif',
		
		function_info		: 'img/function_info.gif',
		
		function_warning		: 'img/function_warning.gif',
		
		package_gif		: 'img/package.gif',
	
		package_error		: 'img/package_error.gif',
		
		package_info		: 'img/package_info.gif',
		
		package_warning		: 'img/package_warning.gif',
		
		synonym_gif             : 'img/synonym.gif',
		
		synonym_info		: 'img/synonym_info.gif',
		
		synonym_warning		: 'img/synonym_warning.gif',
		
		synonym_error		: 'img/synonym_error.gif',
		
		sequence_gif        : 'img/sequence.gif',
		
		sequence_info        : 'img/sequence_info.gif',
		
		sequence_warning       : 'img/sequence_warning.gif',
		
		sequence_error        : 'img/sequence_error.gif',
		
		
		datatype_gif        : 'img/datatype.gif',
		
		datatype_info        : 'img/datatype_info.gif',
		
		datatype_warning       : 'img/datatype_warning.gif',
		
		datatype_error        : 'img/datatype_error.gif',
				
		
		
		private_procedure_gif        : 'img/private_procedure.gif',
		
		private_procedure_info        : 'img/private_procedure_info.gif',
		
		private_procedure_warning       : 'img/private_procedure_warning.gif',
		
		private_procedure_error        : 'img/private_procedure_error.gif',
		
		
		
		private_synonym_gif        : 'img/private_synonym.gif',
		
		private_synonym_info        : 'img/private_synonym_info.gif',
		
		private_synonym_warning       : 'img/private_synonym_warning.gif',
		
		private_synonym_error        : 'img/private_synonym_error.gif',
		
		
		private_type_gif        : 'img/private_type.gif',
		
		private_type_info        : 'img/private_type_info.gif',
		
		private_type_warning       : 'img/private_type_warning.gif',
		
		private_type_error        : 'img/private_type_error.gif',
		
		
		type_gif        : 'img/type.gif',
		
		type_info        : 'img/type_info.gif',
		
		type_warning       : 'img/type_warning.gif',
		
		type_error        : 'img/type_error.gif',
		
		
		private_function_gif        : 'img/private_function.gif',
		
		private_function_info        : 'img/private_function_info.gif',
		
		private_function_warning       : 'img/private_function_warning.gif',
		
		private_function_error        : 'img/private_function_error.gif',
		
		
		statement_gif        : 'img/statement.gif',
		
		statement_info        : 'img/statement_info.gif',
		
		statement_warning       : 'img/statement_warning.gif',
		
		statement_error        : 'img/statement_error.gif'
		
		
	};