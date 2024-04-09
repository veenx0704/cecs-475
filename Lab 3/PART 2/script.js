document.getElementById('holidayForm').addEventListener('submit', function(event) {
    event.preventDefault(); 

    var countryCode = document.getElementById('txtCountryCode').value;
    var year = document.getElementById('txtYear').value;

    fetchHolidays(countryCode, year);
});

function fetchHolidays(countryCode, year) {
    var apiUrl = `https://date.nager.at/api/v2/PublicHolidays/${year}/${countryCode}`;

    fetch(apiUrl)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        displayHolidays(data);
    })
    .catch(error => {
        console.error('Error fetching holiday data:', error);
    });
}

function displayHolidays(holidays) {
    var table = '<table>';
    table += '<thead><tr><th>Date</th><th>Name</th><th>Local Name</th><th>Country Code</th><th>Global</th></tr></thead>';
    table += '<tbody>';
    holidays.forEach(function (holiday) {
        var dateParts = holiday.date.split('-');
        var formattedDate = dateParts[1] + '/' + dateParts[2] + '/' + dateParts[0];
        table += '<tr>';
        table += `<td>${formattedDate}</td>`;
        table += `<td>${holiday.name}</td>`;
        table += `<td>${holiday.localName}</td>`;
        table += `<td>${holiday.countryCode}</td>`;
        table += `<td>${holiday.global}</td>`;
        table += '</tr>';
    });
    table += '</tbody></table>';

    document.getElementById('holidayData').innerHTML = table;
}
