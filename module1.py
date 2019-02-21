from sys import argv
from sys import platform
import os
import requests
import logs

def main():
    if '--help' in argv or '-h' in argv:
        logs.echoInfo('Usage: ' + argv[0] + ' [BSSID]')
        logs.echoInfo('Example: ' + argv[0] + ' A1:B2:C3:D4:E5:F6')
        exit(0)

    if len(argv) != 2:
        logs.echoInfo('Usage: ' + argv[0] + ' [BSSID]')
        logs.echoInfo('Example: ' + argv[0] + ' A1:B2:C3:D4:E5:F6')
        exit(0)

    bssid = argv[1]

    if len(bssid) != 17:
        logs.echoWarning('Incorrect BSSID')
        logs.echoInfo('BSSID example: A1:B2:C3:D4:E5:F6')
        exit(0)

    session = requests.session()

    response = session.get(
        "https://api.mylnikov.org/geolocation/wifi?bssid=" + bssid + "&v=1.1"
    ).json()

    if response['result'] == 404:
        logs.echoMinus('Could not find location')

    elif response['result'] == 200:
        lat = str(response['data']['lat'])
        lon = str(response['data']['lon'])
        accuracy = str(response['data']['range'])

        logs.echoPlus('Successfully found location')
        print('=' * 28)
        logs.echoInfo('Latitude: ' + lat)
        logs.echoInfo('Longitude: ' + lon)
        logs.echoInfo('Accuracy: ' + accuracy + ' meters')
        print('=' * 28)

        link = 'https://www.google.com/maps/search/' + lat + '+' + lon + '/'

        logs.echoInfo('Google maps link: ' + link)

        if platform in ['win32', 'win64']:
            exit(0)

        else:
            input('\nPress [ENTER] to open the link in firefox')
            os.system('firefox ' + link)

    else:
        logs.echoWarning('Unexpected response of the server')

if __name__ == '__main__':
    try:
        main()
    except KeyboardInterrupt:
        logs.echoInfo('Interrupted\n')
        exit(0)
    except Exception as e:
        logs.echoWarning('Unexpected error: ' + str(e))
