const gulp = require('gulp');
const concat = require('gulp-concat');
const rename = require('gulp-rename');
const uglify = require('gulp-uglify');
const uglifyCss = require('gulp-uglifycss');
const sass = require('gulp-sass');
var del = require('del');
var jade = require('gulp-jade');
var spritesmith = require('gulp.spritesmith'),
    imagemin = require('gulp-imagemin'),
    changed = require('gulp-changed'),
    cheerio = require('gulp-cheerio'),
    raster = require('gulp-raster'),
    merge = require('merge-stream'),
    debug = require('gulp-debug'),
    browserSync = require('browser-sync'),
    stripDebug = require('gulp-strip-debug'),
    insert = require('gulp-insert'),
    path = require('path'),
    fs = require('fs'),
    imageminPngquant = require('imagemin-pngquant');
var token = '';

var jsFiles = [
	'Static/lib/Jquery/jquery-1.11.3.js',
	'Static/lib/Jquery/jquery-migrate-1.0.0.js',
	'Static/lib/bootstrap/js/*.js',
	'Static/lib/modernizr/modernizr.min.js',
	'Static/lib/bootstrap-datetimepicker/moment.js',
	'Static/lib/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js',
	'Static/lib/jssor/*.js',
	'Static/lib/browserBlast/*.js',
	'Static/lib/bootstrap-multiselect/bootstrap-multiselect.js',
	'Static/global/js/MapAreaResponsive.js',
	'Static/lib/jcarousel/*.js',
	'Static/lib/carousel/jquery.bxslider.js',
	'Static/lib/carousel/plugins/jquery.fitvids.js',
	'Static/lib/carousel/plugins/jquery.easing.1.3.js',
	'Static/lib/responsiveslides/responsiveslides.min.js',
	'Static/lib/carousel/owl.carousel.js',
	'Static/lib/jquery.unobtrusive-ajax.min.js',
	'Static/lib/location-js/jquery.csv.min.js',
	'Static/lib/location-js/markerclusterer.js',
	'Static/lib/JqueryValidate/jquery.validate.min.js',
	'Static/highnet/reusable-components/js/slick.js',
	'Static/lib/magnific-popup/jquery.magnific-popup.min.js',
	'Static/global/js/*.js',
	'Static/highnet/js/*.js',
	'Static/highnet/reusable-components/js/site.js',
	'Static/highnet/js/application-form.js'
],
	jsDest = 'dist/scripts',
	jsFilesResidential = [
        'Static/lib/Jquery/jquery-1.11.3.js',
		'Static/lib/Jquery/jquery.ba-throttle-debounce.min.js',
		'Static/lib/bootstrap/js/*.js',
		'Static/lib/slick/slick.js',
		'Static/lib/magnific-popup/jquery.magnific-popup.js',
        'Static/residential/newsite/js/*.js'
	],
	jsDestResidential = 'dist/residential/scripts',
	jsFilesFamily = [
        'Static/lib/Jquery/jquery-1.11.3.js',
		'Static/lib/Jquery/jquery.ba-throttle-debounce.min.js',
		'Static/lib/bootstrap/js/*.js',
		'Static/lib/slick/slick.js',
		'Static/lib/magnific-popup/jquery.magnific-popup.js',
		'Static/lib/mCustomScrollbar/jquery.mCustomScrollbar.js',
        'Static/family/js/*.js'
	],
	jsDestFamily = 'dist/family/scripts',
    jsFilesLeadership = [
        'Static/lib/Jquery/jquery-1.11.3.js',
        'Static/lib/Jquery/jquery.ba-throttle-debounce.min.js',
        'Static/lib/bootstrap/js/*.js',
        'Static/lib/slick/slick.js',
        'Static/lib/magnific-popup/jquery.magnific-popup.js',
        'Static/leadership/js/*.js'
    ],
    jsDestLeadership = 'dist/leadership/scripts';

var cssFiles = [
        'Static/lib/bootstrap/css/bootstrap.min.css',
        'Static/lib/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css',
        'Static/lib/bootstrap-multiselect/bootstrap-multiselect.css',
        'Static/lib/browserBlast/*.css',
        'Static/lib/responsiveslides/responsiveslides.css',
        'Static/highnet/reusable-components/css/slick.css',
        'Static/highnet/reusable-components/css/slick-theme.css',
        'Static/highnet/reusable-components/css/style.css',
        'Static/highnet/reusable-components/css/media.css',
        'Static/lib/magnific-popup/magnific-popup.css',
        'Static/lib/carousel/*.css',
        'Static/styles/styles.scss'
    ],
	cssDest = 'dist/css',
	cssFilesResidential = [
		'Static/lib/bootstrap/css/bootstrap.min.css',
		'Static/lib/slick/slick.css',
		'Static/lib/magnific-popup/magnific-popup.css',
		'Static/residential/newsite/scss/styles.scss'
	],
	cssDestResidential = 'dist/residential/css',
	cssFilesFamily = [
		'Static/lib/bootstrap/css/bootstrap.min.css',
		'Static/lib/slick/slick.css',
		'Static/lib/magnific-popup/magnific-popup.css',
	    'Static/lib/mCustomScrollbar/jquery.mCustomScrollbar.css',
		'Static/family/scss/styles.scss'
	],
	cssDestFamily = 'dist/family/css',
    cssFilesLeadership = [
        'Static/lib/bootstrap/css/bootstrap.min.css',
        'Static/lib/slick/slick.css',
        'Static/lib/magnific-popup/magnific-popup.css',
        'Static/leadership/scss/styles.scss'
    ],
	cssDestLeadership = 'dist/leadership/css';

var fontFiles = [
        'Static/lib/bootstrap/fonts/*.*',
        'Static/fonts/*.*'
    ],
	fontDest = 'dist/fonts',
	fontFilesResidential = [
		'Static/lib/bootstrap/fonts/*.*',
		'Static/fonts/roboto/*.*'
	],
	fontDestResidential = 'dist/residential/fonts',
	fontFilesFamily = [
		'Static/lib/bootstrap/fonts/*.*',
		'Static/fonts/zilla-slab/*.*',
	    'Static/fonts/*.*'

	],
	fontDestFamily = 'dist/family/fonts',
    fontFilesLeadership = [
        'Static/lib/bootstrap/fonts/*.*',
		'Static/fonts/droidserif/*.*',
        'Static/fonts/*.*'
    ],
	fontDestLeadership = 'dist/leadership/fonts';

var jadeResidentialFiles = [
        'Static/residential/newsite/**/*.jade'
    ],
    jadeResidentialDest = 'dist/residential';

var imageResidentialFiles = [
        'Static/residential/newsite/**/*.png',
        'Static/residential/newsite/**/*.jpg',
        'Static/residential/newsite/**/*.jpeg',
    ],
    imageResidentialDest = 'dist/residential';
	
var jadeFamilyFiles = [
        'Static/family/**/*.jade'
    ],
	jadeFamilyDest = 'dist/family';

var imageFamilyFiles = [
        'Static/family/**/*.png',
        'Static/family/**/*.jpg',
        'Static/family/**/*.jpeg',
		'Static/lib/mCustomScrollbar/mCSB_buttons.png'
    ],
	imageFamilyDest = 'dist/family';

var jadeLeadershipFiles = [
        'Static/leadership/**/*.jade'
    ],
	jadeLeadershipDest = 'dist/leadership';

var imageLeadershipFiles = [
        'Static/leadership/**/*.png',
        'Static/leadership/**/*.jpg',
        'Static/leadership/**/*.jpeg',
    ],
	imageLeadershipDest = 'dist/leadership';

var config = (function() {
    var UID = 'High.Net.Web/',
        build = 'dist/',
        bower = 'bower_components/',
        core = '',
        config = {
            debug: true,
            paths: {
                bower: bower,
                UID: UID,
                core: core,
                build: build,
                spritesheetsOut: build + 'images/spritesheets/',
                assetsOut: build,
                sassSrc: 'Static/highnet/css',
                iconsOut: UID + 'images/icons/',
                svgsSrc: UID + 'images/svgs/',
                svgsOut: build + 'images/svgs/',
                svgIconsOut: build + 'images/icons/',
                imagesMinificationSrc: build + 'images/',
                imagesMinificationOut: build + 'images/',
            }
        };

    config.dev = {
        copy: {
            js: (function() {
                var o = {};

                //from->to
                //o[config.paths.jsVendorSrc + 'vendor.js'] = build + 'js/libs';
                //o[bower + 'lightcase/src/js/lightcase.js'] = build + 'js/libs';
                //o[bower + 'FancySelect/fancySelect.js'] = build + 'js/libs';
                //o[bower + 'responsive-tabs/js/jquery.responsiveTabs.min.js'] = build + 'js/libs';
                //o[bower + 'sumoselect/jquery.sumoselect.min.js'] = build + 'js/libs';
                //o[bower + 'slick-carousel/slick/slick.min.js'] = build + 'js/libs';
                //o[bower + 'respond/dest/respond.min.js'] = build + 'js/libs';

                return o;
            })(),
            css: {},
            assets: (function() {
                var o = {};

                //from->to
                //o[config.paths.assetsSrc + '/**'] = config.paths.assetsOut;
                //o[UID + 'data/**'] = build + 'html/';

                return o;
            })(),
            images: (function() {
                var o = {};

                //from->to
                o[UID + 'Static/highnet/**'] = UID + 'dist/images/';

                return o;
            })(),
            fonts: (function() {
                var o = {};

                //from->to
                //o[bower + 'lightcase/src/fonts/**'] = build + 'fonts/';

                return o;
            })()
        }
    };

    config.build = {};

    config.sass = {
        options: {
            outputStyle: 'nested', //nested, expanded, compact, compressed
            precision: 8,
            includePaths: [bower, core + 'sass'],
        },
        buildOptions: {
            outputStyle: 'nested', //nested, expanded, compact, compressed
            precision: 8,
            includePaths: [bower, core + 'sass'],
        }
    };

    config.browserSync = {
        options: {
            //server: {
            //    baseDir: build
            //},
            //startPath: path.relative(build, config.paths.htmlOut),
            ////port: 8080, //change port
            //browser: ['chrome'],//,'firefox'
            //reloadDelay: 400//Time (in milliseconds), to wait before instructing the browser to reload/inject following a change event
        }
    };
    config.imageminPngquant = { //DEV: Adds lossy compression to PNGs - significant filesize reduction for negligible quality loss
        usePngquant: true,
        options: {
            quality: '65-80', //0 = worst, 100 = perfect
            speed: 3 //1 = best quality, 10 = fastest - default is 3
        }
    };

    config.raster = {
        //options:{}
    };

    config.rename = {};

    //additional options
    config.imagemin = {
        options: {
            progressive: true,
            svgoPlugins: [{ removeViewBox: false }],
            use: (config.imageminPngquant ? [imageminPngquant(config.imageminPngquant.options)] : [])
        }
    };

    config.spritesmith = {
        options: {
            imgName: 'sprite.png',
            imgPath: '../images/spritesheets/sprite.png', //path.relative(config.paths.cssOut, config.paths.spritesheetsOut).replace(/\\/g, '/') + '/sprite.png',
            cssName: '_sprite.scss',
            padding: 2,
            algorithm: 'diagonal'
                //DEV: Can enable retian support if you have hi res versions of ALL your images
                //retinaSrcFilter: config.paths.iconsSrc+'/*@2x.png',
                //retinaImgName:'sprite@2x.png',
                //retinaImgPath:path.relative( config.paths.cssOut, config.paths.iconsOut ).replace(/\\/g,'/')+'/sprite@2x.png'
        }
    };

    return config;
})();

var isBrowserSync = false;
//create a stream to copy a set of files
function copy(paths, cb) {
    var stream = merge();

    for (var srcDir in paths) {
        if (!paths.hasOwnProperty(srcDir)) {
            continue;
        }

        var destinationDir = paths[srcDir];

        var readPath = srcDir,
            writePath = destinationDir;

        debug("Read from: " + readPath);
        debug("Write to: " + writePath);

        stream.add(gulp.src(readPath)
            .pipe(gulp.dest(writePath))
        );
    }

    if (stream.isEmpty()) {
        if (cb instanceof Function) {
            cb();
        }

        return;
    }

    return stream;
}

gulp.task('dev:svg', [], function(cb) {
    //Shelved: Custom SVG spritesheet generation
    //TODO a whole load of features would be nice for the future
    /*try{
		svgConfig = require( './'+config.paths.svgsSrc+'config.js' )();
	}
	catch( e ){
		debug( 'Failed to parse config:' );
		debug( e );

		return null;
	}*/

    //Look in SVG folder, if a file has changed generate a PNG icon of it
    var stream = gulp.src(config.paths.svgsSrc + '*.svg')
        .pipe(changed(config.paths.svgIconsOut, { extension: '.png' })) //only convert files that have changed
        .pipe(cheerio({ //stupid kludge to fix issue where raster crops SVG
            run: function($) {
                var viewbox = $('svg').attr('viewbox'),
                    width,
                    height;

                if (!viewbox) {
                    return;
                }

                width = Math.ceil(+viewbox.split(' ')[2]);
                height = Math.ceil(+viewbox.split(' ')[3]);

                if (isNaN(width) || isNaN(height)) {
                    return;
                }

                $('svg')
                    .append('<rect fill="#ffffff" width="' + width + '" height="' + height + '" fill-opacity="0"/>');
            }
        }))
        .pipe(raster())
        .pipe(rename({ extname: '.png' }))

    .pipe(gulp.dest(config.paths.svgIconsOut));

    //copy generated SVGs
    var copyPaths = {};
    copyPaths[config.paths.svgsSrc + '**/*.*'] = config.paths.svgsOut
    var copyStream = copy(copyPaths);

    return copyStream && !copyStream.isEmpty() ? merge(stream, copyStream) : stream;
});

gulp.task('dev:sprites', function() {
    var spriteData = gulp.src(config.paths.iconsSrc + '*.png')
        .pipe(spritesmith(config.spritesmith.options));
    //separate CSS and image write locations
    var imgStream = spriteData.img
        .pipe(gulp.dest(config.paths.spritesheetsOut));
    if (isBrowserSync) {
        //This doesn't work, as browsersync does not appear to update images in CSS

        /*imgStream = imgStream.pipe(browserSync.reload({
			stream:true,
			reloadDelay:config.browserSync.options.reloadDelay
		}));*/

        //I need to do this instead otherwise browserSync simply ignores the changed image (but does update the CSS, leading to a broken page).
        //This forces a full reload. Not ideal, but it works
        imgStream.pipe(
            map(function(data, cb) {
                browserSync.reload();

                cb(null, data);
            })
        );
    }
    //output generated Sass file
    var cssStream = spriteData.css
        .pipe(gulp.dest(config.paths.sassSrc));
    //copy icons to output folder
    var copyPaths = {};
    copyPaths[config.paths.iconsSrc + '**/*.*'] = config.paths.iconsOut;
    var copyStream = copy(copyPaths);

    imgStream = copyStream && !copyStream.isEmpty() ? merge(imgStream, copyStream) : imgStream;

    // Return a merged stream to handle both `end` events
    return merge(cssStream, imgStream);
})

gulp.task('highnet-clean', function() {
    return del([
		'dist/css',
		'dist/fonts',
		'dist/scripts',
        'token.txt'
    ]);
});

gulp.task('residential-clean', function () {
	return del([
		'dist/residential',
		'token.txt'
	]);
});
gulp.task('family-clean', function () {
	return del([
		'dist/family',
		'token.txt'
	]);
});
gulp.task('leadership-clean', function () {
    return del([
        'dist/leadership',
        'token.txt'
    ]);
});
gulp.task('scss', function() {
    return gulp.src(cssFiles)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('styles.css'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(gulp.dest(cssDest))
        .pipe(rename('styles.min.css'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(uglifyCss({
            "amxLineLen": 80,
            "uglyComments": true
        }))
        .pipe(gulp.dest(cssDest));
});

gulp.task('residential-scss', function () {
	return gulp.src(cssFilesResidential)
		.pipe(sass().on('error', sass.logError))
		.pipe(concat('styles.css'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(gulp.dest(cssDestResidential))
		.pipe(rename('styles.min.css'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(uglifyCss({
			"amxLineLen": 80,
			"uglyComments": true
		}))
		.pipe(gulp.dest(cssDestResidential));
});
gulp.task('family-scss', function () {
	return gulp.src(cssFilesFamily)
		.pipe(sass().on('error', sass.logError))
		.pipe(concat('styles.css'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(gulp.dest(cssDestFamily))
		.pipe(rename('styles.min.css'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(uglifyCss({
			"amxLineLen": 80,
			"uglyComments": true
		}))
		.pipe(gulp.dest(cssDestFamily));
});
gulp.task('leadership-scss', function () {
    return gulp.src(cssFilesLeadership)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('styles.css'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(gulp.dest(cssDestLeadership))
        .pipe(rename('styles.min.css'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(uglifyCss({
            "amxLineLen": 80,
            "uglyComments": true
        }))
        .pipe(gulp.dest(cssDestLeadership));
});
gulp.task('scripts', function() {
    return gulp.src(jsFiles)
        //.pipe(concat('scripts_' + token + '.js'))
        .pipe(concat('scripts.js'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(gulp.dest(jsDest))
        .pipe(rename('scripts.min.js'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDest));;
});

gulp.task('residential-scripts', function () {
	return gulp.src(jsFilesResidential)
		//.pipe(concat('scripts_' + token + '.js'))
		.pipe(concat('scripts.js'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(gulp.dest(jsDestResidential))
		.pipe(rename('scripts.min.js'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(uglify())
		.pipe(gulp.dest(jsDestResidential));;
});
gulp.task('family-scripts', function () {
	return gulp.src(jsFilesFamily)
		.pipe(concat('scripts.js'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(gulp.dest(jsDestFamily))
		.pipe(rename('scripts.min.js'))
		.pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
		.pipe(uglify())
		.pipe(gulp.dest(jsDestFamily));;
});
gulp.task('leadership-scripts', function () {
    return gulp.src(jsFilesLeadership)
        .pipe(concat('scripts.js'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(gulp.dest(jsDestLeadership))
        .pipe(rename('scripts.min.js'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(uglify())
		.pipe(gulp.dest(jsDestLeadership));;
});
gulp.task('residential-jade', function () {
    gulp.src(jadeResidentialFiles)
        .pipe(jade({ pretty: true }))
        .pipe(gulp.dest(jadeResidentialDest));
});
gulp.task('family-jade', function () {
    gulp.src(jadeFamilyFiles)
        .pipe(jade({ pretty: true }))
        .pipe(gulp.dest(jadeFamilyDest));
});
gulp.task('leadership-jade', function () {
    gulp.src(jadeLeadershipFiles)
        .pipe(jade({ pretty: true }))
		.pipe(gulp.dest(jadeLeadershipDest));
});
gulp.task('residential-images', function () {
    gulp.src(imageResidentialFiles)
        .pipe(gulp.dest(imageResidentialDest));
});
gulp.task('family-images',
    function() {
        gulp.src(imageFamilyFiles)
            .pipe(gulp.dest(imageFamilyDest));
	});
gulp.task('leadership-images',
    function () {
        gulp.src(imageLeadershipFiles)
			.pipe(gulp.dest(imageLeadershipDest));
    });

gulp.task('scripts-dev', function () {
    return gulp.src(jsFiles)
        .pipe(concat('scripts.js'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(gulp.dest(jsDest))
        .pipe(rename('scripts.min.js'))
        .pipe(insert.prepend('/* ' + token + ' */\n\n\n'))
        .pipe(gulp.dest(jsDest));;
});

gulp.task('fonts', function() {
    return gulp.src(fontFiles)
        .pipe(gulp.dest(fontDest));;
});

gulp.task('residential-fonts', function () {
	return gulp.src(fontFilesResidential)
		.pipe(gulp.dest(fontDestResidential));;
});
gulp.task('family-fonts', function () {
	return gulp.src(fontFilesFamily)
		.pipe(gulp.dest(fontDestFamily));;
});
gulp.task('leadership-fonts', function () {
    return gulp.src(fontFilesLeadership)
		.pipe(gulp.dest(fontDestLeadership));;
});
gulp.task('gen_token', function(cb) {
    token = (new Date()).getTime();
    fs.writeFile('token.txt', token + '\n' + (new Date(token)).toString(), cb);
});

gulp.task('browserSync', function() {
    isBrowserSync = true;

    return browserSync(config.browserSync.options);
});

gulp.task('residential', ['residential-clean'], function () {
	gulp.start(['gen_token', 'residential-scripts', 'dev:sprites', 'residential-scss', 'residential-fonts', 'residential-jade', 'residential-images']);
});
gulp.task('family', ['family-clean'], function () {
	gulp.start(['gen_token', 'family-scripts', 'dev:sprites', 'family-scss', 'family-fonts', 'family-jade', 'family-images']);
});
gulp.task('leadership', ['leadership-clean'], function () {
	gulp.start(['gen_token', 'leadership-scripts', 'dev:sprites', 'leadership-scss', 'leadership-fonts', 'leadership-jade', 'leadership-images']);
});
gulp.task('default', ['highnet-clean'], function () {
	gulp.start(['gen_token', 'scripts', 'dev:sprites', 'scss', 'fonts', "residential", "family", "leadership"]);
    //gulp.start(["residential"]);
});

gulp.task('build-dev', ['highnet-clean'], function () {
    gulp.start(['gen_token', 'scripts-dev', 'dev:sprites', 'scss', 'fonts']);
});

gulp.task('watch',
    function() {
        var config = {
            includeCss: '*.css',
            includeScss: '*.scss',
			includeJs: '*.js',
			includeJade: '*.jade'
        };

        gulp.watch('Static/residential/newsite/**/' + config.includeCss, ["scss", "residential-scss"]);
		gulp.watch('Static/residential/newsite/**/' + config.includeScss, ["scss", "residential-scss"]);
		gulp.watch('Static/residential/newsite/**/' + config.includeJs, ["scripts", "residential-scripts"]);
		gulp.watch('Static/residential/newsite/**/' + config.includeJade, ["residential-jade"]);
		
		gulp.watch('Static/family/**/' + config.includeCss, ["family-scss"]);
		gulp.watch('Static/family/**/' + config.includeScss, ["family-scss"]);
		gulp.watch('Static/family/**/' + config.includeJs, ["family-scripts"]);
		gulp.watch('Static/family/**/' + config.includeJade, ["family-jade"]);

        gulp.watch('Static/leadership/**/' + config.includeCss, ["leadership-scss"]);
		gulp.watch('Static/leadership/**/' + config.includeScss, ["leadership-scss"]);
		gulp.watch('Static/leadership/**/' + config.includeJs, ["leadership-scripts"]);
		gulp.watch('Static/leadership/**/' + config.includeJade, ["leadership-jade"]);
    });