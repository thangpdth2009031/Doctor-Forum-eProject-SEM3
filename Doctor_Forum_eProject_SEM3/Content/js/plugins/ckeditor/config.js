/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.language = 'vi';   
    /*config.filebrowserBrowseUrl = '/Content/js/plugins/ckfinder/ckfinder.html',
    config.filebrowserImageBrowseUrl = '/Content/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
    config.filebrowserFlashBrowseUrl = '/Areas/Admin/Content/plugins/ckfinder/ckfinder.html',
    config.filebrowserUploadUrl = '/Areas/Admin/Content/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',    
    config.filebrowserImageUploadUrl = '/Areas/Admin/Content/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
    config.filebrowserFlashUploadUrl = '/Areas/Admin/Content/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',*/
    config.filebrowserBrowseUrl = '/Content/js/plugins/ckfinder/ckfinder.html',
        config.filebrowserUploadUrl = '/Content/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',

    config.filebrowserWindowWidth = '1000',
        config.filebrowserWindowHeight = '700'
    CKFinder.setupCKEditor(null, '/Content/js/plugins/ckfinder/')
};
