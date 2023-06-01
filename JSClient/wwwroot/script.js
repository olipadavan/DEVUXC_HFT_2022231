let seasons = [];
let sponsors = [];
let teams = [];
let connection = null;
getSeasonData();
getSponsorData();
getTeamData();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:2201/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SeasonCreated", (user, message) => {
        getdata();
    });

    connection.on("SeasonDeleted", (user, message) => {
        getdata();
    });
    connection.on("SponsorCreated", (user, message) => {
        getdata();
    });

    connection.on("SponsorDeleted", (user, message) => {
        getdata();
    });
    connection.on("TeamCreated", (user, message) => {
        getdata();
    });

    connection.on("TeamDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    Start();
}

async function Start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getSeasonData() {
    await fetch('http://localhost:2201/Season/ReadAll')
        .then(x => x.json())
        .then(y => {
            seasons = y
            console.log(seasons);
            DisplaySeason();
        });
}
async function getSponsorData() {
    await fetch('http://localhost:2201/Sponsor')
        .then(x => x.json())
        .then(y => {
            sponsors = y
            console.log(sponsors);
            DisplaySponsor();
        });
}
async function getTeamData() {
    await fetch('http://localhost:2201/Team')
        .then(x => x.json())
        .then(y => {
            teams = y
            console.log(teams);
            DisplayTeam();
        });
}

function DisplaySeason() {
    document.getElementById('resultarea').innerHTML = "";
    seasons.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.SeasonID + "</td><td>"
            + t.SeasonName + "</td><td>" +
            `<button type="button" onclick="removeSeason(${t.SeasonId})">Delete</button>`
            + "</td></tr>";
    });
}
function DisplaySponsor() {
    document.getElementById('resultarea2').innerHTML = "";
    sponsors.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.SponsorID + "</td><td>"
            + t.SponsorName + "</td><td>" +
            `<button type="button" onclick="removeSponsor(${t.SponsorID})">Delete</button>`
            + "</td></tr>";
    });
}
function DisplayTeam() {
    document.getElementById('resultarea3').innerHTML = "";
    teams.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.TeamID + "</td><td>"
            + t.TeamName + "</td><td>" +
            `<button type="button" onclick="removeTeam(${t.TeamID})">Delete</button>`
            + "</td></tr>";
    });
}

function removeSeason(id) {
    fetch('http://localhost:2201/Season/ReadAll/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getSeasonData();
        })
        .catch((error) => { console.error('Error:', error); });

}
function removeSponsor(id) {
    fetch('http://localhost:2201/Sponsor/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getSponsorData();
        })
        .catch((error) => { console.error('Error:', error); });

}
function removeTeam(id) {
    fetch('http://localhost:2201/Team/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getTeamData();
        })
        .catch((error) => { console.error('Error:', error); });

}

function CreateSeason() {
    let name = document.getElementById('SeasonName').value;
    fetch('http://localhost:2201/Season/ReadAll', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                SeasonName: name,

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getSeasonData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function CreateSponsor() {
    let name = document.getElementById('SponsorName').value;
    fetch('http://localhost:2201/Sponsor', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                SponsorName: name,

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getSponsorData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function CreateTeam() {
    let name = document.getElementById('TeamName').value;
    fetch('http://localhost:2201/Team', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                TeamName: name,

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getTeamData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}