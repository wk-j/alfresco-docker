
Action<string,string> process = (c, args) => {
    StartProcess(c, new ProcessSettings {
        Arguments = args
    });
};

Task("Compose-Up").Does(() => {
    process("docker-compose", "up -d --build");
});

Task("Remove-All").Does(() => {
    process("npm", "run remove");
});

Task("Download-Modules").Does(() => {
    process("mmt", "download");
});

var target = Argument("target", "default");
RunTarget(target);