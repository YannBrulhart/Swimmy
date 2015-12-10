module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        copy: {
            main: {
                files: [
                    {
                        expand: true,
                        cwd: 'bower_components/angucomplete-alt/dist/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular/dist/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular/dist/',
                        src: ['**/*.css'],
                        dest: 'Content/css/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular-base64/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular-bootstrap/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular-bootstrap/',
                        src: ['**/*.css'],
                        dest: 'Content/css/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular-file-upload/dist',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular-loading-bar/build/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/angular-loading-bar/build/',
                        src: ['**/*.css'],
                        dest: 'Content/css/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap/dist/js/',
                        src: ['**/*.js'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap/dist/fonts/',
                        src: ['**/*.*'],
                        dest: 'Content/fonts/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap/dist/css/',
                        src: ['**/*.css', '**/*.map'],
                        dest: 'Content/css/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/jquery/dist/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/raty/lib/',
                        src: ['**/*.css'],
                        dest: 'Content/css/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/raty/lib/',
                        src: ['**/*.js'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/raty/lib/fonts',
                        src: ['**/*.*'],
                        dest: 'Content/fonts/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/raty/lib/images',
                        src: ['**/*.png'],
                        dest: 'Content/images/raty'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/tg-angular-validator/dist/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/toastr/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'scripts/Vendors/'
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/toastr/',
                        src: ['**/*.css', '**/*.map'],
                        dest: 'Content/css/'
                    },
                ]
            }
        }        
    });

    // Load externally defined tasks. 
    grunt.loadNpmTasks('grunt-contrib-copy');

    // Establish tasks we can run from the terminal.
    grunt.registerTask('default', ['copy']);
}