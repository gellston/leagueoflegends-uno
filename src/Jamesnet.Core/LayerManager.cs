namespace Jamesnet.Core;

public class LayerManager : ILayerManager
{
    private readonly Dictionary<string, ILayer> _layers = new Dictionary<string, ILayer>();
    private readonly Dictionary<string, List<IView>> _layerViews = new Dictionary<string, List<IView>>();
    private readonly Dictionary<string, IView> _layerViewMappings = new Dictionary<string, IView>();

    public void Register(string layerName, ILayer layer)
    {
        if (!_layers.ContainsKey(layerName))
        {
            _layers[layerName] = layer;
            _layerViews[layerName] = new List<IView>();

            if (_layerViewMappings.TryGetValue(layerName, out var view))
            {
                Add(layerName, view);
                Show(layerName, view);
            }
        }
    }

    public void Show(string layerName, IView view)
    {
        if (!_layers.TryGetValue(layerName, out var layer))
        {
            throw new InvalidOperationException($"Layer not registered: {layerName}");
        }

        if (view == null)
        {
            layer.Content = null;
            return;
        }

        if (!_layerViews.TryGetValue(layerName, out var views) || !views.Contains(view))
        {
            Add(layerName, view);
        }

        layer.Content = view;
    }


    public void Add(string layerName, IView view)
    {
        if (!_layerViews.TryGetValue(layerName, out var views))
        {
            throw new InvalidOperationException($"Layer not registered: {layerName}");
        }
        if (!views.Contains(view))
        {
            views.Add(view);
        }
    }

    public void Hide(string layerName)
    {
        if (_layers.TryGetValue(layerName, out var layer))
        {
            layer.Content = null;
        }
    }

    public void Mapping(string layerName, IView view)
    {
        _layerViewMappings[layerName] = view;
    }
}
