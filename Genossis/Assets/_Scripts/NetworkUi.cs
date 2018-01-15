using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUi : MonoBehaviour
{
    public Button joinButton;
    public Button hostButton;
    public GameObject hostPanel;
    public Text ipAddressText;

    public void HostGame()
    {
        CustomNetworkDiscovery.Instance.StartBroadcasting();
        NetworkController.singleton.StartHost();
    }

    public void ReceiveGameBroadcast()
    {
        CustomNetworkDiscovery.Instance.ReceiveBraodcast();
    }

    public void JoinGame()
    {
        NetworkController.singleton.networkAddress = ipAddressText.text;
        NetworkController.singleton.StartClient();
        CustomNetworkDiscovery.Instance.StopBroadcasting();
    }

    public void OnReceiveBraodcast(string fromIp, string data)
    {
        hostButton.gameObject.SetActive(false);
        joinButton.gameObject.SetActive(false);
        ipAddressText.text = fromIp;
        hostPanel.SetActive(true);
    }

    void Start()
    {
        CustomNetworkDiscovery.Instance.onServerDetected += OnReceiveBraodcast;
    }

    void OnDestroy()
    {
        CustomNetworkDiscovery.Instance.onServerDetected -= OnReceiveBraodcast;
    }
}
