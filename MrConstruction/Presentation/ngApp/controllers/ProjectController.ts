namespace MrConstruction.Controllers {
    export class ProjectController {

        public projects;
        public modalInstance;
       

        constructor(private $uibModal, private $http: ng.IHttpService) {
            $http.get('/api/project')
                .then((response) => {
                    this.projects = response.data;
                });
        }

        public showModal(): void {
            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/newProject.html',
                controller: MrConstruction.Controllers.NewProjectController,
                controllerAs: 'controller',
                size: 'lg',
                backdrop: true,
            });

            this.modalInstance.result
                .then((newProject) => {
                    this.$http.post('/api/project', newProject)
                        .then((response) => {
                            this.projects = response.data;
                            console.log("post successful");
                        })
                })
                .catch((dismiss) => {
                });

            //    public newProject(project) {
            //    console.log(project);
            //    this.$http.post('/api/project', project
            //    ).then((response) => {
            //        this.$location.path("#/projectDetails")
            //        console.log("post successful");
            //    }).catch((response) => {
            //        console.log(`uh oh, error ${response}`);
            //    });
            //}
        }
    }
}
