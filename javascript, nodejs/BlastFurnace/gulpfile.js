var gulp = require('gulp'),
jade = require('gulp-jade');
sass = require('gulp-sass');

// Jade
gulp.task('jade', function(){
  gulp.src('./client/*.jade')
    .pipe(jade())
    .pipe(gulp.dest('./client/'))
});

// Sass
gulp.task('sass', function(){
  gulp.src('./client/*.sass')
    //.pipe(sass.sync().on('error', sass.logError))
    .pipe(sass())
    .pipe(gulp.dest('./client/'))
});

// Watch
gulp.task('watch', function(){
  gulp.watch('./client/*.jade',['jade']);
  gulp.watch('./client/*.sass',['sass']);
});