let Seasons = [];
let Sponsors = [];
let Teams = [];
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
        getSeasonData();
    });

    connection.on("SeasonDeleted", (user, message) => {
        getSeasonData();
    });
    connection.on("SponsorCreated", (user, message) => {
        getSponsorData();
    });

    connection.on("SsponsorDeleted", (user, message) => {
        getSponsorData();
    });
    connection.on("TeamCreated", (user, message) => {
        getTeamData();
    });

    connection.on("TeamDeleted", (user, message) => {
        getTeamData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
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
            Seasons = y;
            console.log(Seasons);
            DisplaySeason();
        });
}

async function getSponsorData() {
    await fetch('http://localhost:2201/Sponsor')
        .then(x => x.json())
        .then(y => {
            Sponsors = y;
            console.log(Sponsors);
            DisplaySponsor();
        });
}

async function getTeamData() {
    await fetch('http://localhost:2201/Team')
        .then(x => x.json())
        .then(y => {
            Teams = y;
            console.log(Teams);
            DisplayTeam();
        });
}

function DisplaySeason() {
    document.getElementById('resultarea').innerHTML = "";
    Seasons.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.seasonYear + "</td><td>" +
            `<button type="button" onclick="removeSeason(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}
function DisplaySponsor() {
    document.getElementById('resultarea2').innerHTML = "";
    Sponsors.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="removeSponsor(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}
function DisplayTeam() {
    document.getElementById('resultarea3').innerHTML = "";
    Teams.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="removeTeam(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function removeSeason(id) {
    fetch('http://localhost:2201/Season/Delete/' + id, {
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

function createSeason() {
    let year = document.getElementById('seasonyear').value;
    fetch('http://localhost:2201/Season/Post', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { seasonYear: year })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getSeasonData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function createSponsor() {
    let name = document.getElementById('sponsorname').value;
    fetch('http://localhost:2201/Sponsor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getSponsorData();
        })
        .catch((error) => { console.error('Error:', error); });
}
function createTeam() {
    let name = document.getElementById('teamname').value;
    fetch('http://localhost:2201/Team', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getTeamData();
        })
        .catch((error) => { console.error('Error:', error); });
}